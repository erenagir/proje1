using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proje1.UI.Models.RequestModels.Invoices
{
    public class CreateInvoiceVM
    {
        public int RequestFormId { get; set; }
        public DateTime InvoiceDate { get; set; }
        public string CompanyName { get; set; }
        public string ProductDetail { get; set; }
        public double TotalPrice { get; set; }
    }
}
