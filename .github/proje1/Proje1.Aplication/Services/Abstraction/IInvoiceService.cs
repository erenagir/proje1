using Proje1.Aplication.Models.Dtos.Department;
using Proje1.Aplication.Models.Dtos.Invoice;
using Proje1.Aplication.Models.RequestModels.Department;
using Proje1.Aplication.Models.RequestModels.Invoices;
using Proje1.Aplication.Wrapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proje1.Aplication.Services.Abstraction
{
    public interface IInvoiceService
    {
        Task<Result<int>> CreateInvoice(CreateInvoiceVM createInvoiceVM );
        Task<Result<List<InvoiceDto>>> GetAllInvoice();



    }
}
