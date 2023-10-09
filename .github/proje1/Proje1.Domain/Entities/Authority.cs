using Proje1.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proje1.Domain.Entities
{
    public class Authority:BaseEntity
    {
        public int PersonId { get; set; }
        public bool Admin { get; set; }
        public bool Request { get; set; }
        public bool Approve { get; set; }
        public bool Receive { get; set; }
        public bool Accounting { get; set; }
        public bool management { get; set; }
       // public Person Person { get; set; }
    }
}
