using AutoMapper;
using AutoMapper.QueryableExtensions;
using Proje1.Aplication.Exceptions;
using Proje1.Aplication.Models.Dtos.RequestForm;
using Proje1.Aplication.Models.RequestModels.RequestForm;
using Proje1.Aplication.Services.Abstraction;
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
    public class RequestFromService : IRequestFormService
    {

        private readonly IMapper _mapper;
        private readonly IUWork _uWork;

        public RequestFromService(IUWork uWork, IMapper mapper)
        {
            _uWork = uWork;
            _mapper = mapper;
        }

        public async Task<Result<List<RequestDto>>> GetAllRequest()
        {
            var result=new Result<List<RequestDto>>();
            var requestEntity= await _uWork.GetRepository<RequestForm>().GetAllAsync();
            var requestDtos=requestEntity.ProjectTo<RequestDto>(_mapper.ConfigurationProvider).ToList();

            result.Data = requestDtos;
            return result;
        }
        public async Task<Result<int>> CreateRequest(CreateRequestVM createRequestVM)
        {
           var result=new Result<int>();
           var requestEntity= _mapper.Map<RequestForm>(createRequestVM);
           _uWork.GetRepository<RequestForm>().Add(requestEntity);
           await _uWork.ComitAsync();
            result.Data = requestEntity.Id;
            return result;
        }

      

        public  async Task<Result<int>> UpdateRequest(UpdateRequestVM updateRequestVM)
        {
            var result = new Result<int>();
            var requestEntity=await _uWork.GetRepository<RequestForm>().GetById(updateRequestVM.Id);
            if(requestEntity == null)
            {
                throw new NotFoundException("istek bulunamadı");

            }
            _mapper.Map(updateRequestVM, requestEntity);
             _uWork.GetRepository<RequestForm>().Update(requestEntity);
            await _uWork.ComitAsync();
            result.Data = requestEntity.Id;
            return result;
        }
    }
}
