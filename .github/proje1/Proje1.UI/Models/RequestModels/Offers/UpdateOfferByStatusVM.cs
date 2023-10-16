using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proje1.UI.Models.RequestModels.Offers
{
    public class UpdateOfferByStatusVM
    {
        public int Id{ get; set; }

        public OfferStatus OfferStatus { get; set; }
    }
}
