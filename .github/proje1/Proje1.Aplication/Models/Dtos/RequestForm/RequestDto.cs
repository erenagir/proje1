using Proje1.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proje1.Aplication.Models.Dtos.RequestForm
{
    public class RequestDto
    {
        public int Id { get; set; }
        public int PersonId { get; set; }
        public string Name { get; set; }
        public string Detail { get; set; }
        public string Products { get; set; }
        public Status Status { get; set; }
    }
}
