﻿using Proje1.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proje1.Aplication.Models.RequestModels.Offers
{
    public class UpdateOfferVM
    {
        public int Id{ get; set; }

        public OfferStatus OfferStatus { get; set; }
    }
}
