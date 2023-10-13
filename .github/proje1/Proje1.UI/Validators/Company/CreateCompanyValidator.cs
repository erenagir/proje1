using FluentValidation;
using Proje1.UI.Models.RequestModels.Company;

namespace Proje1.Aplication.Validators.Company
{
    public class CreateCompanyValidator:AbstractValidator<CreateCompanyVM>
    {

        public CreateCompanyValidator()
        {
            RuleFor(x => x.CompanyName)
                .NotNull().WithMessage("şirket adı boş olamaz.")
                .MaximumLength(150).WithMessage("şiket adı 150 karakterden büyük olamaz.");
        }
    }
}
