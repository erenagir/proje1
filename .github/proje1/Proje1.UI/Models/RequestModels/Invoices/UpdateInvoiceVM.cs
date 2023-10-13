using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proje1.UI.Models.RequestModels.Invoices
{
    public class UpdateInvoiceVM

    {
        public int Id { get; set; }
        public string CompanyName { get; set; }
        public string ProductDetail { get; set; }
        public double TotalPrice { get; set; }
    }
}
