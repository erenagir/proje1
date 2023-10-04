using AutoMapper;
using Proje1.Aplication.Models.RequestModels.Person;
using Proje1.Aplication.Models.RequestModels.Product;
using Proje1.Aplication.Models.RequestModels.RequestForm;
using Proje1.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proje1.Aplication.AutoMapper
{
    public class ViewModelToDomain:Profile
    {

        public ViewModelToDomain()
        {
            CreateMap<ReisterVM, Person>();
            CreateMap<ReisterVM,Account>();


            CreateMap<CreateProductVM,Product>();
            CreateMap<CreateRequestVM, RequestForm>()
                .ForMember(x => x.Status,Y=>Y.MapFrom(e=>Status.pending));


            CreateMap<UpdateRequestVM, RequestForm>();
        }
    }
}
