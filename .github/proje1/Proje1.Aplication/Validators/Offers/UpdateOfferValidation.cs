using FluentValidation;
using Proje1.Aplication.Models.RequestModels.Offers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proje1.Aplication.Validators.Offers
{
    public class UpdateOfferValidation:AbstractValidator<UpdateOfferVM>
    {
        public UpdateOfferValidation()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("id bilgisi boş olamaz");
          
        }
    }
}
