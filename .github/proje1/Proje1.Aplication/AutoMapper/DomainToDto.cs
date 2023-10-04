using AutoMapper;
using Proje1.Aplication.Models.Dtos.Person;
using Proje1.Aplication.Models.Dtos.Product;
using Proje1.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proje1.Aplication.AutoMapper
{
    public class DomainToDto:Profile
    {
        public DomainToDto()
        {
            CreateMap<Product,ProductDto>();
            CreateMap<Person,PersonDto>();
        }

    }
}
