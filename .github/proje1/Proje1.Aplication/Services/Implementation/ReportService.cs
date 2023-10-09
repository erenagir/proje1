using AutoMapper;
using AutoMapper.QueryableExtensions;
using Proje1.Aplication.Models.Dtos.Report;
using Proje1.Aplication.Models.RequestModels.Report;
using Proje1.Aplication.Services.Abstraction;
using Proje1.Aplication.Wrapper;
using Proje1.Domain.Entities;
using Proje1.Domain.UWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proje1.Aplication.Services.Implementation
{
    public class ReportService : IReportService
    {
        private readonly IMapper _mapper;
        private readonly IUWork _uWork;

        public ReportService(IUWork uWork, IMapper mapper)
        {
            _uWork = uWork;
            _mapper = mapper;
        }


        public async Task<Result<List<ReportDto>>> GetAllReport()
        {
            var result = new Result<List<ReportDto>>();
            var reports = await _uWork.GetRepository<Report>().GetAllAsync();

            var reportDtos=reports.ProjectTo<ReportDto>(_mapper.ConfigurationProvider).ToList();
            result.Data= reportDtos;
            return result;

        }
        public async Task<Result<List<ReportDto>>> GetReporByDepartment(GetReportVM getReportVM)
        {
            var result = new Result<List<ReportDto>>();
            var reports = await _uWork.GetRepository<Report>().GetByFilterAsync(x=>x.DepartmentId==getReportVM.Id);

            var reportDtos = reports.ProjectTo<ReportDto>(_mapper.ConfigurationProvider).ToList();
            result.Data = reportDtos;
            return result;
        }

        public async Task<Result<List<ReportDto>>> GetReportByPerson(GetReportVM getReportVM)
        {
            var result = new Result<List<ReportDto>>();
            var reports = await _uWork.GetRepository<Report>().GetByFilterAsync(x => x.PersonID == getReportVM.Id);

            var reportDtos = reports.ProjectTo<ReportDto>(_mapper.ConfigurationProvider).ToList();
            result.Data = reportDtos;
            return result;
        }
    }
}
