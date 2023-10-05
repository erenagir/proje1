using FluentValidation;
using Proje1.Aplication.Models.RequestModels.Company;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

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
