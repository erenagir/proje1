using Proje1.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proje1.Domain.Entities
{
    public class Account:BaseEntity
    {
        public int PersonId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public Person Person { get; set; }
    }
}
