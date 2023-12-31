﻿using AutoMapper;
using Proje1.Aplication.Models.Dtos.Company;
using Proje1.Aplication.Models.Dtos.Department;
using Proje1.Aplication.Models.Dtos.Invoice;
using Proje1.Aplication.Models.Dtos.Offers;
using Proje1.Aplication.Models.Dtos.Person;
using Proje1.Aplication.Models.Dtos.Product;
using Proje1.Aplication.Models.Dtos.Report;
using Proje1.Aplication.Models.Dtos.RequestForm;
using Proje1.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Proje1.Aplication.AutoMapper
{
    public class DomainToDto:Profile
    {
        public DomainToDto()
        {
            CreateMap<Company,CompanyDto>();
            CreateMap<Department,DepartmentDto>();
            CreateMap<Invoice,InvoiceDto>();
            CreateMap<Product,ProductDto>();
            CreateMap<Person,PersonDto>();
            CreateMap<RequestForm,RequestDto>();
            CreateMap<Offer,OfferDto>();

            CreateMap<Report, ReportDto>()
                .ForMember(x => x.Username, y => y.MapFrom(x => x.Person.UserName))
                .ForMember(x => x.DepartmentName, y => y.MapFrom(x => x.Department.DepartmantName));
        }

    }
}
