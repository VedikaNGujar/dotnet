using System.Net.Http;

namespace Mango.Web.Service.IService
{
    public interface IHttpClientService
    {

        Task<TResponse?> GetAsync<TResponse>(string url);

        Task<TResponse?> PostAsync<TRequest, TResponse>(string url, TRequest data);

        Task<TResponse?> PutAsync<TRequest, TResponse>(string url, TRequest data);

        Task<bool> DeleteAsync(string url);

    }
}
