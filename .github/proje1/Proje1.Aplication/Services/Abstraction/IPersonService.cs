using Proje1.Aplication.Models.Dtos.Person;
using Proje1.Aplication.Models.RequestModels.Person;
using Proje1.Aplication.Wrapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proje1.Aplication.Services.Abstraction
{
    public interface IPersonService
    {
        Task<Result<bool>> Register(ReisterVM reisterVM);
        Task<Result<TokenDto>> Login(LoginVM loginVM);

    }
}
