using Proje1.Aplication.Models.Dtos.Company;
using Proje1.Aplication.Models.RequestModels.Company;
using Proje1.Aplication.Models.RequestModels.Person;
using Proje1.Aplication.Wrapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proje1.Aplication.Services.Abstraction
{
    public interface ICompanyService
    {
        Task<Result<int>> CreateCompany(CreateCompanyVM createCompanyVM);
        Task<Result<List<CompanyDto>>> GetAllCompany();
    }
}
