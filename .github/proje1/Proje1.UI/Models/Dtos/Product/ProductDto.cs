using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proje1.UI.Models.Dtos.Product
{
    public class ProductDto
    {
        public int Id { get; set; }
        public int DepartmentId { get; set; }
        public string Name { get; set; }
        public string ProductDetail { get; set; }
        public int Stock { get; set; }
    }
}
