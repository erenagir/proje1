using Proje1.Aplication.Models.Dtos.Company;
using Proje1.Aplication.Models.Dtos.Department;
using Proje1.Aplication.Models.RequestModels.Company;
using Proje1.Aplication.Models.RequestModels.Department;
using Proje1.Aplication.Wrapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proje1.Aplication.Services.Abstraction
{
    public interface IDepartmentService
    {
        Task<Result<int>> CreateDepartment(CreateDepartmentVM createDepartmentVM);
        Task<Result<List<DepartmentDto>>> GetAllDepartmentByCompany(GetAllDepartmentByCompanyVM getAllDepartmentByCompanyVM);
    }
}
