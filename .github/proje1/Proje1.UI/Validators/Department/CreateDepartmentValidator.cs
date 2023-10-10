using FluentValidation;
using Proje1.UI.Models.RequestModels.Department;

namespace Proje1.UI.Validators.Company
{
    public class CreateDepartmentValidator : AbstractValidator<CreateDepartmentVM>
    {

        public CreateDepartmentValidator()
        {
            RuleFor(x=>x.CompanyId)
                .NotNull().WithMessage("şirket adı boş olamaz.");
            RuleFor(x => x.DepartmantName)
                .NotNull().WithMessage("departman adı boş olamaz.")
                .MaximumLength(150).WithMessage("departman adı 150 karakterden büyük olamaz.");
        }
    }
}
