using Proje1.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proje1.Domain.Entities
{
    public class RequestForm: AuditableEntity
    {   
       
        public int PersonId { get; set; }
        public string Name { get; set; }
        public string Detail { get; set; }
        public string Products { get; set; }
        public Status Status { get; set; }
        public Person Person { get; set; }
       

        public ICollection<Invoice> Invoices  { get; set; }
        public ICollection<Offer> Offers { get; set; }
    }

    public enum Status
    {
        pending=1,//bekleme
        approved,//onaylandı
        refuse//ret 
    }
}
