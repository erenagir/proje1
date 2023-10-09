using AutoMapper;
using AutoMapper.QueryableExtensions;
using Proje1.Aplication.Behaviors;
using Proje1.Aplication.Exceptions;
using Proje1.Aplication.Models.Dtos.Department;
using Proje1.Aplication.Models.Dtos.Invoice;
using Proje1.Aplication.Models.RequestModels.Department;
using Proje1.Aplication.Models.RequestModels.Invoices;
using Proje1.Aplication.Services.Abstraction;
using Proje1.Aplication.Validators.Invoıces;
using Proje1.Aplication.Wrapper;
using Proje1.Domain.Entities;
using Proje1.Domain.UWork;

namespace Proje1.Aplication.Services.Implementation
{
    public class InvoıceService : IInvoiceService
    {
        private readonly IMapper _mapper;
        private readonly IUWork _uWork;

        public InvoıceService(IUWork uWork, IMapper mapper)
        {
            _uWork = uWork;
            _mapper = mapper;
        }

        [ValidationBehavior(typeof(CreateInvoicesValidator))]
        public async Task<Result<int>> CreateInvoice(CreateInvoiceVM createInvoiceVM)
        {
            var result = new Result<int>();
            var requestExists = await _uWork.GetRepository<RequestForm>().AnyAsync(x => x.Id == createInvoiceVM.RequestFormId);
            if (!requestExists)
            {
                throw new NotFoundException($"{createInvoiceVM.RequestFormId} bilgili talep bulunamdı");

            }
            var invoiceEntity = _mapper.Map<Invoice>(createInvoiceVM);
            _uWork.GetRepository<Invoice>().Add(invoiceEntity);
            await _uWork.ComitAsync($"{invoiceEntity.Id} kimlik numaralı fatura eklendi");
            result.Data = invoiceEntity.Id;
            return result;

        }

        public async Task<Result<List<InvoiceDto>>> GetAllInvoice()
        {
            var result = new Result<List<InvoiceDto>>();
            var ınvoicesEntity = await _uWork.GetRepository<Invoice>().GetAllAsync();
            var invoiceDtos = ınvoicesEntity.ProjectTo<InvoiceDto>(_mapper.ConfigurationProvider).ToList();
            result.Data = invoiceDtos;
            return result;
        }
    }
}
