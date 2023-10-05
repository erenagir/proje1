using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proje1.Aplication.Models.Dtos.Department
{
    public class DepartmentDto
    {
        public int Id { get; set; }
        public int CompanyId { get; set; }
        public string DepartmantName { get; set; }
    }
}
