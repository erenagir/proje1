using Proje1.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proje1.Aplication.Models.RequestModels.Person
{
    public class UpdatePersonVM
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
       
    }
}
