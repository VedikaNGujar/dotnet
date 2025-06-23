using Mango.Web.Helper;
using Mango.Web.Models;
using Mango.Web.Service.IService;

namespace Mango.Web.Service
{
    public class OrderService : IOrderService
    {
        private readonly IBaseService _baseService;
        public OrderService(IBaseService baseService)
        {
            _baseService = baseService;
        }

       

        public async Task<ResponseDto?> CreateOrder(CartDto cartDto)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.HttpMethodType.POST,
                Data = cartDto,
                URL =  SD.OrderAPIBase + "/api/order/CreateOrder"
            });
        }

        public async Task<ResponseDto?> CreateStripeSession(StripeRequestDto stripeRequestDto)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.HttpMethodType.POST,
                Data = stripeRequestDto,
                URL =  SD.OrderAPIBase + "/api/order/CreateStripeSession"
            });
        }

        public async Task<ResponseDto?> GetAllOrder(string? userId)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.HttpMethodType.GET,
                URL =  SD.OrderAPIBase + "/api/order/GetOrders?userId=" + userId
            });
        }

        public async Task<ResponseDto?> GetOrder(int orderId)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.HttpMethodType.GET,
                URL =  SD.OrderAPIBase + "/api/order/GetOrder/" + orderId
            });
        }

        public async Task<ResponseDto?> UpdateOrderStatus(int orderId, string newStatus)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.HttpMethodType.POST,
                Data = newStatus,
                URL =  SD.OrderAPIBase + "/api/order/UpdateOrderStatus/"+orderId
            });
        }

        public async Task<ResponseDto?> ValidateStripeSession(int orderHeaderId)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.HttpMethodType.POST,
                Data = orderHeaderId,
                URL =  SD.OrderAPIBase + "/api/order/ValidateStripeSession"
            });
        }
    }
}
