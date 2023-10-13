using Proje1.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proje1.Aplication.Models.Dtos.Person
{
    public class TokenDto
    {
        public int Id { get; set; }
        public int DepartmentId { get; set; }

        public Roles Role { get; set; }
        public string Token { get; set; }
        public DateTime Expiredate { get; set; }
    }
}
