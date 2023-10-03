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
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public Roles Role { get; set; }

        public Account Account { get; set; }
    }

    public enum Roles
    {
        Employee=1,
        Manager,
        Purchase,//satın alma
        Accounting,//muhasebe
        admin
    }
}
