﻿using Proje1.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Proje1.Aplication.Models.RequestModels.RequestForm
{
    public class UpdateRequestVM
    {
        public int Id { get; set; }
        public Status Status { get; set; }

        
    }
}
