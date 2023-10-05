using FluentValidation;
using Proje1.Aplication.Models.RequestModels.Company;
using Proje1.Aplication.Models.RequestModels.Department;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Proje1.Aplication.Validators.Company
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
