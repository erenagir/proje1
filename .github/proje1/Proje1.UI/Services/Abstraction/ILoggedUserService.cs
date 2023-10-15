using Proje1.UI.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proje1.UI.Services.Abstraction
{
    public interface ILoggedUserService
    {
        int? UserId { get; }
         int? DepartmentId { get; }
         Roles? Role { get; }
      
    }
}
