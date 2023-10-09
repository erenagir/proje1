using Proje1.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proje1.Domain.Entities
{
    public class Report:BaseEntity
    {
        public int PersonID { get; set; }
        public int DepartmentId { get; set; }

        public string detail { get; set; }
        public DateTime Date { get; set; }
        public Person Person { get; set; }
        public Department Department { get; set; }

    }
}
