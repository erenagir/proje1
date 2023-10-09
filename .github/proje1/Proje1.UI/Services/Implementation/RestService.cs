using Proje1.UI.Models.Dtos.Person;
using Proje1.UI.Services.Abstraction;
using RestSharp;
using System.Net;

namespace Proje1.UI.Services.Implementation
{
    public class RestService : IRestService
    {

        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _contextAccessor;

        public RestService(IConfiguration configuration, IHttpContextAccessor contextAccessor)
        {
            _configuration = configuration;
            _contextAccessor = contextAccessor;
        }
        public Task<RestResponse<TResponse>> DeleteAsync<TResponse>(string endpointUrl, bool tokenRequired = true)
        {
            throw new NotImplementedException();
        }

        public Task<RestResponse<TResponse>> GetAsync<TResponse>(string endpointUrl, bool tokenRequired = true)
        {
            throw new NotImplementedException();
        }

        public Task<RestResponse<TResponse>> PostAsync<TRequest, TResponse>(TRequest requestModel, string endpointUrl, bool tokenRequired = true)
        {
            throw new NotImplementedException();
        }

        public Task<RestResponse<TResponse>> PostAsync<TResponse>(string endpointUrl, bool tokenRequired = true)
        {
            throw new NotImplementedException();
        }

        public Task<RestResponse<TResponse>> PostFormAsync<TResponse>(Dictionary<string, string> parameters, string endpointUrl, bool tokenRequired = true)
        {
            throw new NotImplementedException();
        }

        public Task<RestResponse<TResponse>> PutAsync<TRequest, TResponse>(TRequest requestModel, string endpointUrl, bool tokenRequired = true)
        {
            throw new NotImplementedException();
        }


        #region Private Methods

        private TokenDto GetToken()
        {
            var sessionKey = _configuration["Application:SessionKey"];
            if (_contextAccessor.HttpContext.Session.GetString(sessionKey) is null)
                return null;
            var tokenDto = JsonConvert.DeserializeObject<TokenDto>(_contextAccessor.HttpContext.Session.GetString(sessionKey));
            return tokenDto;
        }

        private void CheckResponse<TResponse>(RestResponse<TResponse> response)
        {
            if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                throw new UnauthenticatedException();
            }
            else if (response.StatusCode == HttpStatusCode.Forbidden)
            {
                throw new UnauthorizedException();
            }
        }

        private void AddFormParametersToRequest(RestRequest request, Dictionary<string, string> parameters)
        {
            foreach (var key in parameters.Keys)
            {
                request.AddParameter(key, parameters[key]);
            }
        }

        #endregion
    }
}
