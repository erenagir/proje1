using Proje1.Aplication.Models.Dtos.RequestForm;
using Proje1.Aplication.Models.RequestModels.Offers;
using Proje1.Aplication.Models.RequestModels.RequestForm;
using Proje1.Aplication.Wrapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proje1.Aplication.Services.Abstraction
{
    public interface  IRequestFormService
    {
        Task<Result<List<RequestDto>>> GetAllRequest();
       
        Task<Result<List<RequestDto>>> GetRequestByDepartment(GetRequestVM getrequestVM);

        Task<Result<int>> CreateRequest(CreateRequestVM createRequestVM);
        Task<Result<int>> UpdateRequest(UpdateRequestVM updateRequestVM);


    }
}
