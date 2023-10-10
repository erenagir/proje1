using FluentValidation;
using Proje1.UI.Models.RequestModels.Invoices;

namespace Proje1.UI.Validators.Invoıces
{
    public class CreateInvoicesValidator : AbstractValidator<CreateInvoiceVM>
    {
        public CreateInvoicesValidator()
        {
            RuleFor(x => x.RequestFormId)
              .NotEmpty().WithMessage("İstek bilgisi boş olamaz.")
              .LessThan(82).WithMessage("Geçersiz bir il numarası gönderildi.");
            RuleFor(x => x.InvoiceDate)
              .NotEmpty().WithMessage("Tarih bilgisi  boş olamaz.");
            RuleFor(x => x.CompanyName)
                .NotEmpty().WithMessage("şirket  bilgisi boş olamaz.")
                .MaximumLength(150).WithMessage("Ad bilgisi 150 karakterden büyük olamaz.");
            RuleFor(x => x.ProductDetail)
               .NotEmpty().WithMessage("ürün  bilgisi boş olamaz.");
            RuleFor(x => x.TotalPrice)
               .NotEmpty().WithMessage("ürün  bilgisi boş olamaz.")
               ;


        }
    }
}





