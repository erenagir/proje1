using Proje1.Aplication.Models.Dtos.Offers;
using Proje1.Aplication.Models.Dtos.Report;
using Proje1.Aplication.Models.RequestModels.Offers;
using Proje1.Aplication.Models.RequestModels.Report;
using Proje1.Aplication.Wrapper;
using Proje1.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proje1.Aplication.Services.Abstraction
{
    public interface IReportService
    {
        Task<Result<List<ReportDto>>> GetAllReport();
        Task<Result<List<ReportDto>>> GetReportByPerson(GetReportVM getReportVM);
        Task<Result<List<ReportDto>>> GetReporByDepartment(GetReportVM getReportVM);
    }
}
