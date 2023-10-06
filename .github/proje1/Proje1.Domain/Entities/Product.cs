using Proje1.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proje1.Domain.Entities
{
    public class Product:AuditableEntity
    {
        public int DepartmentId { get; set; }
        public string Name { get; set; }
        public string ProductDetail { get; set; }
        public int Stock { get; set; }
        public Department Department { get; set; }
    }
}
