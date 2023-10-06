using FluentValidation;
using Proje1.Aplication.Models.RequestModels.Department;
using Proje1.Aplication.Models.RequestModels.Invoices;
using Proje1.Aplication.Models.RequestModels.Offers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proje1.Aplication.Validators.Invoıces
{
    public class CreateOfferValidator : AbstractValidator<CreateOfferVM>
    {
        public CreateOfferValidator()
        {
            RuleFor(x => x.RequestformId)
              .NotEmpty().WithMessage("İstek bilgisi boş olamaz.")
              .LessThan(82).WithMessage("Geçersiz bir istek numarası gönderildi.");
           
            RuleFor(x => x.CompanyName)
                .NotEmpty().WithMessage("şirket  bilgisi boş olamaz.")
                .MaximumLength(150).WithMessage("Ad bilgisi 150 karakterden büyük olamaz.");
            RuleFor(x => x.Address)
               .NotEmpty().WithMessage("şirket adres bilgisi boş olamaz.")
             .MaximumLength(30).WithMessage("Ad bilgisi 30 karakterden büyük olamaz.");

            RuleFor(x => x.CompanyPhone)
                .NotEmpty().WithMessage("şirket telefon  bilgisi boş olamaz.")
                .MaximumLength(10).WithMessage("Ad bilgisi 10 karakterden büyük olamaz.");
            RuleFor(x => x.CompanyEmail)
               .NotEmpty().WithMessage("ürün  bilgisi boş olamaz.")
                .MaximumLength(150).WithMessage("Ad bilgisi 150 karakterden büyük olamaz.");
            RuleFor(x => x.TotalPrice)
               .NotEmpty().WithMessage("ürün  bilgisi boş olamaz.");


        }
    }
}

