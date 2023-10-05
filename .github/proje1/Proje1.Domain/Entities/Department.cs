using Proje1.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proje1.Domain.Entities
{
    public class Department:BaseEntity
    {
        public int CompanyId { get; set; }
        public string DepartmantName { get; set; }

        public Company Company { get; set; }
        public  ICollection<Person> Persons { get; set; }
        public  ICollection<Report> Reports { get; set; }
    }
}
