using FluentValidation;
using Proje1.UI.Models.RequestModels.Offers;

namespace Proje1.Aplication.Validators.Offers
{
    public class UpdateOfferValidation:AbstractValidator<UpdateOfferByStatusVM>
    {
        public UpdateOfferValidation()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("id bilgisi boş olamaz");
           
        }
    }
}
