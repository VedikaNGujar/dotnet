using Mango.Web.Service.IService;

namespace Mango.Web.Service
{
    public class HttpClientService : IHttpClientService
    {
        private readonly HttpClient _httpClient;

        public HttpClientService(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient();
        }

        public async Task<TResponse?> GetAsync<TResponse>(string url)
        {
            var response = await _httpClient.GetAsync(url);
            return await HandleResponse<TResponse>(response);
        }

        public async Task<TResponse?> PostAsync<TRequest, TResponse>(string url, TRequest data)
        {
            var response = await _httpClient.PostAsJsonAsync(url, data);
            return await HandleResponse<TResponse>(response);
        }

        public async Task<TResponse?> PutAsync<TRequest, TResponse>(string url, TRequest data)
        {
            var response = await _httpClient.PutAsJsonAsync(url, data);
            return await HandleResponse<TResponse>(response);
        }

        public async Task<bool> DeleteAsync(string url)
        {
            var response = await _httpClient.DeleteAsync(url);
            return response.IsSuccessStatusCode;
        }

        private async Task<T?> HandleResponse<T>(HttpResponseMessage response)
        {
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<T>();
            }

            // Optional: throw or log error
            var error = await response.Content.ReadAsStringAsync();
            Console.WriteLine($"Error: {response.StatusCode} - {error}");
            return default;
        }
    }
}

