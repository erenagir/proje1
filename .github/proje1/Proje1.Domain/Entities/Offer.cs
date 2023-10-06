using Proje1.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proje1.Domain.Entities
{
    public class Offer:AuditableEntity
    {
        public int RequestformId { get; set; }
        public string CompanyName { get; set; }
        public string Address { get; set; }
        public string  CompanyPhone { get; set; }
        public string CompanyEmail { get; set; }
        public  RequestForm RequestForm { get; set; }

        public double TotalPrice { get; set; }
    }
}
