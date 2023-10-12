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
using Proje1.Utils;

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


        #region get_istekleri

       
        public async Task<Result<List<InvoiceDto>>> GetAllInvoice()
        {
            var result = new Result<List<InvoiceDto>>();
            var ınvoicesEntity = await _uWork.GetRepository<Invoice>().GetAllAsync();
            var invoiceDtos = ınvoicesEntity.ProjectTo<InvoiceDto>(_mapper.ConfigurationProvider).ToList();
            result.Data = invoiceDtos;
            return result;
        }

        public async Task<Result<List<InvoiceDto>>> GetInvoiceByCompany(GetInvoiceVM getInvoiceVM)
        {
            var result = new Result<List<InvoiceDto>>();
            var ınvoicesEntity = await _uWork.GetRepository<Invoice>().GetByFilterAsync(x => x.Department.CompanyId == getInvoiceVM.Id, "Department");
            var invoiceDtos = ınvoicesEntity.ProjectTo<InvoiceDto>(_mapper.ConfigurationProvider).ToList();
            result.Data = invoiceDtos;
            return result;
        }

        public async Task<Result<List<InvoiceDto>>> GetInvoiceByDepartment(GetInvoiceVM getInvoiceVM)
        {
            var result = new Result<List<InvoiceDto>>();
            var ınvoicesEntity = await _uWork.GetRepository<Invoice>().GetByFilterAsync(x => x.DepartmentId == getInvoiceVM.Id);
            var invoiceDtos = ınvoicesEntity.ProjectTo<InvoiceDto>(_mapper.ConfigurationProvider).ToList();
            result.Data = invoiceDtos;
            return result;
        }

        public async Task<Result<List<InvoiceDto>>> GetInvoiceByRequestForm(GetInvoiceVM getInvoiceVM)
        {
            var result = new Result<List<InvoiceDto>>();
            var ınvoicesEntity = await _uWork.GetRepository<Invoice>().GetByFilterAsync(x => x.RequestFormId == getInvoiceVM.Id);
            var invoiceDtos = ınvoicesEntity.ProjectTo<InvoiceDto>(_mapper.ConfigurationProvider).ToList();
            result.Data = invoiceDtos;
            return result;
        }



        #endregion

        [ValidationBehavior(typeof(CreateInvoicesValidator))]
        public async Task<Result<int>> CreateInvoice(CreateInvoiceVM createInvoiceVM)
        {
            var result = new Result<int>();
            var requestExists = await _uWork.GetRepository<RequestForm>().GetSingleByFilterAsync(x => x.Id == createInvoiceVM.RequestFormId, "Person");
            if (requestExists is null)
            {
                throw new NotFoundException($"{createInvoiceVM.RequestFormId} bilgili talep bulunamdı");

            }
            var invoiceEntity = _mapper.Map<Invoice>(createInvoiceVM);
            _uWork.GetRepository<Invoice>().Add(invoiceEntity);
            await _uWork.ComitAsync($"{invoiceEntity.RequestFormId} kimlik numaralı talebe fatura girişi  yapıldı");
            MailUtils.SendMail(requestExists.Person.Email, "ürün girişi", "talebiniz tamamlanmıştır");
            result.Data = invoiceEntity.Id;
            return result;
        }


        [ValidationBehavior(typeof(UpdateInvoiceValidator))]
        public async Task<Result<int>> UpdateInvoice(UpdateInvoiceVM updateInvoiceVM)
        {
            var existsEntity = await _uWork.GetRepository<Invoice>().GetById(updateInvoiceVM.Id);
            if (existsEntity == null)
            {
                throw new NotFoundException("fatura bilgisi bulunamadı");

            }
            existsEntity = _mapper.Map(updateInvoiceVM, existsEntity);
            var result = new Result<int>();
            result.Data = existsEntity.Id;
            _uWork.GetRepository<Invoice>().Update(existsEntity);
            _uWork.ComitAsync($"{existsEntity.Id} kimlik numaralı fatura güncellendi");
            return result;



        }
    }
}
