using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proje1.Aplication.Models.RequestModels.Product
{
    public class CreateProductVM
    {
        public string Name { get; set; }
        public string ProductDetail { get; set; }
        public int Stock { get; set; }
    }
}
