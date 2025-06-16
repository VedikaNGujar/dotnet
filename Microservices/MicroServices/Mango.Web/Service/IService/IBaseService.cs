using Mango.Web.Models;

namespace Mango.Web.Service.IService
{
    public interface IBaseService //<T, K> where T : class where K : class
    {
        Task<ResponseDto> SendAsync(RequestDto requestDto, bool withBearer = true);
    }
}
