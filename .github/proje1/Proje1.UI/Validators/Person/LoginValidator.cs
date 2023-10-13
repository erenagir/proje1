using FluentValidation;
using Proje1.UI.Models.RequestModels.Person;

namespace Ahlatci.Shop.UI.Validators.Accounts
{
    public class LoginValidator : AbstractValidator<LoginVM>
    {
        public LoginValidator()
        {
            RuleFor(x => x.UserName)  
                .NotNull().WithMessage("Kullanıcı adı boş olamaz.")
                .MaximumLength(10).WithMessage("Kullanıcı adı en fazla 10 karakter olabilir.");

            RuleFor(x => x.Password)
                .NotNull().WithMessage("Parola boş olamaz.")
                .MaximumLength(10).WithMessage("Parola en fazla 10 karakter olabilir.");
        }
    }
}
