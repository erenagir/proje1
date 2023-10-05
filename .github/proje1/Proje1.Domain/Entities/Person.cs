using Proje1.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Proje1.Domain.Entities
{
    public class Person:BaseEntity
    {
        public int departmantId { get; set; }
       
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }

        public string UserName { get; set; }
        public string Password { get; set; }

        public Authority Authority  { get; set; }
        public Department Department { get; set; }
        public  ICollection<RequestForm> RequestForms { get; set; }
        public  ICollection<Report> Reports { get; set; }
    }

   
}
