using FluentValidation;
using Proje1.UI.Models.RequestModels.Offers;

namespace Proje1.Aplication.Validators.Offers
{
    public class UpdateOfferValidation:AbstractValidator<UpdateOfferVM>
    {
        public UpdateOfferValidation()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("id bilgisi boş olamaz");
            RuleFor(x=>x.TotalPrice)
                .NotEmpty().WithMessage("id bilgisi boş olamaz");
        }
    }
}
