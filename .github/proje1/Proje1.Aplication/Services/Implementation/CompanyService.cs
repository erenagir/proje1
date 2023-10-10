using AutoMapper;
using AutoMapper.QueryableExtensions;
using Proje1.Aplication.Behaviors;
using Proje1.Aplication.Models.Dtos.Company;
using Proje1.Aplication.Models.RequestModels.Company;
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
    public class CompanyService : ICompanyService
    {

        private readonly IMapper _mapper;
        private readonly IUWork _uWork;

        public CompanyService(IUWork uWork, IMapper mapper)
        {
            _uWork = uWork;
            _mapper = mapper;
        }

        [ValidationBehavior(typeof(CreateDepartmentValidator))]
        public async Task<Result<int>> CreateCompany(CreateCompanyVM createCompanyVM)
        {
            var result = new Result<int>();

            var companyEntity = _mapper.Map<Company>(createCompanyVM);
            _uWork.GetRepository<Company>().Add(companyEntity);
            await _uWork.ComitAsync($"{companyEntity.CompanyName}  şirketi oluşturuldu");
            result.Data = companyEntity.Id;
            return result;
        }

        public async Task<Result<List<CompanyDto>>> GetAllCompany()
        {
            var result= new Result<List<CompanyDto>>();
            var companyEntites=await _uWork.GetRepository<Company>().GetAllAsync();
            var companyDtos = companyEntites.ProjectTo<CompanyDto>(_mapper.ConfigurationProvider).ToList();
            result.Data = companyDtos;
            return result;
        }
    }
}
