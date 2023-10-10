using FluentValidation;
using Proje1.UI.Models.RequestModels.Offers;

namespace Proje1.UI.Validators.Offers
{
    public class DeleteOfferValidation:AbstractValidator<DeleteOfferVM>
    {

        public DeleteOfferValidation()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("silinecek teklif ID boş olamaz");
        }
    }
}
