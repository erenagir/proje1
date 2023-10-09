using Proje1.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proje1.Aplication.Models.RequestModels.Person
{
    public class ReisterVM
    {
        public int departmantId { get; set; }

        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }

        public string UserName { get; set; }
        public string Password { get; set; }
        public Roles Role { get; set; }
    }
}
