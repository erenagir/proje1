using Proje1.Aplication.Models.Dtos.Offers;
using Proje1.Aplication.Models.Dtos.RequestForm;
using Proje1.Aplication.Models.RequestModels.Offers;
using Proje1.Aplication.Models.RequestModels.RequestForm;
using Proje1.Aplication.Wrapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proje1.Aplication.Services.Abstraction
{
    public interface IOfferService
    {
        Task<Result<List<OfferDto>>> GetAllOfferByRequest(GetAllOfferByRequestVM getAllOfferByRequestVM);
        Task<Result<List<OfferDto>>> GetAllOfferByRequestOk(GetAllOfferByRequestOkVM getAllOfferByRequestVM);

        Task<Result<int>> CreateOffer(CreateOfferVM createOfferVM);
        Task<Result<int>> UpdateOffer(UpdateOfferVM updateOfferVM);
        Task<Result<int>> DeleteOffer(DeleteOfferVM deleteOfferVM);

        Task<Result<int>> UpdateOffer(UpdateOfferByStatusVM updateOfferByStatusVM);
    }
}
