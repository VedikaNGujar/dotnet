using Mango.Web.Helper;
using static Mango.Web.Helper.SD;

namespace Mango.Web.Models
{
    public class RequestDto
    {
        public HttpMethodType ApiType { get; set; } = HttpMethodType.GET;
        public string URL { get; set; }
        public object Data { get; set; }
        public string AccessToken { get; set; } = string.Empty;
    }
}
