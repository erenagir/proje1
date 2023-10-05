using AutoMapper;
using AutoMapper.QueryableExtensions;
using Proje1.Aplication.Behaviors;
using Proje1.Aplication.Exceptions;
using Proje1.Aplication.Models.Dtos.Department;
using Proje1.Aplication.Models.RequestModels.Company;
using Proje1.Aplication.Models.RequestModels.Department;
using Proje1.Aplication.Services.Abstraction;
using Proje1.Aplication.Validators.Company;
using Proje1.Aplication.Wrapper;
using Proje1.Domain.Entities;
using Proje1.Domain.UWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proje1.Aplication.Services.Implementation
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IMapper _mapper;
        private readonly IUWork _uWork;

        public DepartmentService(IUWork uWork, IMapper mapper)
        {
            _uWork = uWork;
            _mapper = mapper;
        }

        [ValidationBehavior(typeof(CreateDepartmentValidator))]
        public async Task<Result<int>> CreateDepartment(CreateDepartmentVM createDepartmentVM)
        {
            var result = new Result<int>();
            var companyExists = await _uWork.GetRepository<Company>().AnyAsync(x=>x.Id==createDepartmentVM.CompanyId);
            if (!companyExists)
            {
                throw new NotFoundException($"{createDepartmentVM.CompanyId} bilgili şirket bulunamdı");

            }
            var departmentEntity = _mapper.Map<Department>(createDepartmentVM);
            _uWork.GetRepository<Department>().Add(departmentEntity);
            await _uWork.ComitAsync();
            result.Data = departmentEntity.Id;
            return result;
        }

        public async Task<Result<List<DepartmentDto>>> GetAllDepartment()
        {
            var result=new Result<List<DepartmentDto>>();
           var departmentEntity=await _uWork.GetRepository<Department>().GetAllAsync();
            var departmentDtos = departmentEntity.ProjectTo<DepartmentDto>(_mapper.ConfigurationProvider).ToList();
           result.Data = departmentDtos;
            return result;
        }
    }
}
