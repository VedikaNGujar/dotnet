using System.Net.Mime;
using System.Text;
using Mango.Web.Helper;
using Mango.Web.Models;
using Mango.Web.Service.IService;
using Newtonsoft.Json;
using static Mango.Web.Helper.SD;

namespace Mango.Web.Service
{
    public class BaseService : IBaseService//<T, K> where T : class where K : class
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public readonly ITokenProvider _tokenProvider;

        public BaseService(IHttpClientFactory httpClientFactory, ITokenProvider tokenProvider)
        {
            _httpClientFactory = httpClientFactory;
            _tokenProvider = tokenProvider;
        }
        public async Task<ResponseDto> SendAsync(RequestDto requestDto, bool withBearer = true)
        {
            HttpClient client = _httpClientFactory.CreateClient("MangoAPI");
            HttpRequestMessage message = new();

            if (requestDto.ContentType == SD.ContentType.MultipartFormData)
            {
                message.Headers.Add("Accept", "*/*");
            }
            else
            {
                message.Headers.Add("Accept", "application/json");
            }


            //message.Headers.Add("Accept", "application/json");

            message.RequestUri = new Uri(requestDto.URL);

            if (withBearer)
            {
                var token = _tokenProvider.GetToken();
                message.Headers.Add("Authorization", $"Bearer {token}");
            }


            if (requestDto.Data != null)
            {

                message.Content = new StringContent(JsonConvert.SerializeObject(requestDto.Data), Encoding.UTF8, "application/json");
            }

            HttpResponseMessage response = new();
            switch (requestDto.ApiType)
            {
                case HttpMethodType.POST:
                    message.Method = HttpMethod.Post;
                    break;
                case HttpMethodType.PUT:
                    message.Method = HttpMethod.Put;
                    break;
                case HttpMethodType.DELETE:
                    message.Method = HttpMethod.Delete;
                    break;
                default:
                    message.Method = HttpMethod.Get;
                    break;
            }

            try
            {
                response = await client.SendAsync(message);

                switch (response.StatusCode)
                {
                    case System.Net.HttpStatusCode.NotFound:
                        return new() { IsSuccess = false, Message = "Not Found" };
                    case System.Net.HttpStatusCode.Forbidden:
                        return new() { IsSuccess = false, Message = "Forbidden" };
                    case System.Net.HttpStatusCode.Unauthorized:
                        return new() { IsSuccess = false, Message = "Unauthorized" };
                    case System.Net.HttpStatusCode.InternalServerError:
                        return new() { IsSuccess = false, Message = "Internal Server Error" };
                    default:
                        var result = await response.Content.ReadAsStringAsync();
                        if (result != null)
                            return JsonConvert.DeserializeObject<ResponseDto>(result);
                        else return new() { IsSuccess = false };

                }

            }
            catch (Exception ex)
            {

                return new ResponseDto
                {
                    IsSuccess = false,
                    Message = ex.Message,
                };
            }
        }
    }
}
