using AutoMapper;
using Proje1.Aplication.Models.RequestModels.Company;
using Proje1.Aplication.Models.RequestModels.Department;
using Proje1.Aplication.Models.RequestModels.Invoices;
using Proje1.Aplication.Models.RequestModels.Offers;
using Proje1.Aplication.Models.RequestModels.Person;
using Proje1.Aplication.Models.RequestModels.Product;
using Proje1.Aplication.Models.RequestModels.RequestForm;
using Proje1.Domain.Entities;

namespace Proje1.Aplication.AutoMapper
{
    public class ViewModelToDomain : Profile
    {

        public ViewModelToDomain()
        {
            CreateMap<CreateCompanyVM, Company>();
            CreateMap<CreateDepartmentVM, Department>();
            CreateMap<CreateInvoiceVM, Invoice>();
            CreateMap<UpdateInvoiceVM, Invoice>();


            CreateMap<ReisterVM, Person>();
            CreateMap<CreateOfferVM, Offer>()
                 .ForMember(x => x.offerStatus, y => y.MapFrom(x => OfferStatus.pending));
            CreateMap<UpdateOfferVM, Offer>();
            CreateMap<UpdateOfferByStatusVM, Offer>();

            CreateMap<CreateProductVM, Product>();
            CreateMap<CreateRequestVM, RequestForm>()
                .ForMember(x => x.Status, Y => Y.MapFrom(e => Status.pending));


            CreateMap<UpdateRequestVM, RequestForm>();
        }
    }
}
