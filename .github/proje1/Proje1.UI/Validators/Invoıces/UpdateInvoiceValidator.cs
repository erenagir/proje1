using FluentValidation;
using Proje1.UI.Models.RequestModels.Invoices;

namespace Proje1.Aplication.Validators.Invoıces
{
    public class UpdateInvoiceValidator:AbstractValidator<UpdateInvoiceVM>
    {

        public UpdateInvoiceValidator()
        {
            RuleFor(x=>x.Id)
                .NotEmpty().WithMessage("fatura ıd bilgisi boş olamaz");
            RuleFor(x => x.CompanyName)
               .NotEmpty().WithMessage("fatura şirket  bilgisi boş olamaz")
               .MaximumLength(40).WithMessage("şiket adı 40 karakterden büyük olamaz.");
            
            RuleFor(x => x.ProductDetail)
               .NotEmpty().WithMessage("fatura ürün bilgisi boş olamaz");
            RuleFor(x => x.TotalPrice)
               .NotEmpty().WithMessage("fatura miktar bilgisi boş olamaz");
        }
    }
}
