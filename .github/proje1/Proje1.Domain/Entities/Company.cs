using Proje1.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proje1.Domain.Entities
{
    public class Company:BaseEntity
    {

        public string CompanyName { get; set; }
        public ICollection<Department> Departments { get; set; }
    }
}
