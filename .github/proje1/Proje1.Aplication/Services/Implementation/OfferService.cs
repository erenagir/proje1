using AutoMapper;
using AutoMapper.QueryableExtensions;
using Proje1.Aplication.Behaviors;
using Proje1.Aplication.Exceptions;
using Proje1.Aplication.Models.Dtos.Company;
using Proje1.Aplication.Models.Dtos.Offers;
using Proje1.Aplication.Models.RequestModels.Offers;
using Proje1.Aplication.Services.Abstraction;
using Proje1.Aplication.Validators.Invoıces;
using Proje1.Aplication.Wrapper;
using Proje1.Domain.Entities;
using Proje1.Domain.UWork;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proje1.Aplication.Services.Implementation
{
    public class OfferService : IOfferService
    {

        private readonly IMapper _mapper;
        private readonly IUWork _uWork;

        public OfferService(IUWork uWork, IMapper mapper)
        {
            _uWork = uWork;
            _mapper = mapper;
        }
        public async Task<Result<List<OfferDto>>> GetAllOfferByRequest(GetAllOfferByRequestVM getAllOfferByRequestVM)
        {
            var requestExists = await _uWork.GetRepository<RequestForm>().AnyAsync(x => x.Id == getAllOfferByRequestVM.Id);
            if (!requestExists)
            {
                throw new NotFoundException($"{getAllOfferByRequestVM.Id} nolu talep bulunmadı");
            }

            var result = new Result<List<OfferDto>>();
            var offerEntites = await _uWork.GetRepository<Offer>().GetByFilterAsync(x => x.RequestformId == getAllOfferByRequestVM.Id);
            var offerDtos = offerEntites.ProjectTo<OfferDto>(_mapper.ConfigurationProvider).ToList();
            result.Data = offerDtos;
            return result;
        }

        [ValidationBehavior(typeof(CreateOfferValidator))]
        public async Task<Result<int>> CreateOffer(CreateOfferVM createOfferVM)
        {
            var result = new Result<int>();
            var requestExists = await _uWork.GetRepository<RequestForm>().AnyAsync(x => x.Id == createOfferVM.RequestformId);
            if (!requestExists)
            {
                throw new NotFoundException($"{createOfferVM.RequestformId} nolu talep bulunmadı");
            }
            var offerEntity = _mapper.Map<Offer>(createOfferVM);
            _uWork.GetRepository<Offer>().Add(offerEntity);
            await _uWork.ComitAsync();
            result.Data = offerEntity.Id;
            return result;
        }

        [ValidationBehavior(typeof(CreateOfferValidator))]
        public async Task<Result<int>> DeleteOffer(DeleteOfferVM deleteOfferVM)
        {
            var result = new Result<int>();
            var existsEntity = _uWork.GetRepository<Offer>().GetById(deleteOfferVM.Id);
            if (existsEntity == null)
            {
                throw new NotFoundException("silinecek teklif bilgisi bulunamadı");

            }
            _uWork.GetRepository<Offer>().Delete(existsEntity);
            await _uWork.ComitAsync();
            result.Data = existsEntity.Id;
            return result;
        }


        [ValidationBehavior(typeof(UpdateOfferVM))]
        public async Task<Result<int>> UpdateOffer(UpdateOfferVM updateOfferVM)
        {
           var existsEntity=await _uWork.GetRepository<Offer>().GetById(updateOfferVM.Id);
            if (existsEntity == null)
            {
                throw new NotFoundException("teklif bilgisi bulunamadı");

            }
           existsEntity=_mapper.Map(updateOfferVM, existsEntity);
            var result = new Result<int>();
            result.Data = existsEntity.Id;
            return result;
        }
    }
}
