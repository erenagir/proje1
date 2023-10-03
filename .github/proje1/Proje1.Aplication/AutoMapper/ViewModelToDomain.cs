using AutoMapper;
using Proje1.Aplication.Models.RequestModels;
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
        }
    }
}
