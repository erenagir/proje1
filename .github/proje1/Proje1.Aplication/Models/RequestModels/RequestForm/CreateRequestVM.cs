using Proje1.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proje1.Aplication.Models.RequestModels.RequestForm
{
    public class CreateRequestVM
    {
       
        public string Name { get; set; }
        public string Detail { get; set; }
        public string Products { get; set; }
        
    }
}
