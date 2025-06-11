using Mango.Web.Helper;
using Mango.Web.Models;
using Mango.Web.Service.IService;

namespace Mango.Web.Service
{
    public class CouponService : ICouponService
    {
        private readonly IBaseService _baseService;

        public CouponService(IBaseService baseService)
        {
            this._baseService = baseService;
        }
        public async Task<ResponseDto> CreateCouponsAsync(CouponDto couponDto)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.HttpMethodType.POST,
                Data = couponDto,
                URL = SD.CouponAPIBase + "/api/coupon"
            });
        }

        public async Task<ResponseDto> DeleteCouponsAsync(int id)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.HttpMethodType.DELETE,
                URL = SD.CouponAPIBase + "/api/coupon/" + id
            });
        }

        public async Task<ResponseDto> GetAllCouponsAsync()
        {

            return await _baseService.SendAsync(new RequestDto
            {
                ApiType = SD.HttpMethodType.GET,
                URL = SD.CouponAPIBase + "/api/coupon"
            });
        }

        public async Task<ResponseDto> GetCouponAsync(string couponCode)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.HttpMethodType.GET,
                URL = SD.CouponAPIBase + "/api/coupon/GetByCode/" + couponCode
            });
        }

        public async Task<ResponseDto> GetCouponByIdAsync(int id)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.HttpMethodType.GET,
                URL = SD.CouponAPIBase + "/api/coupon/" + id
            });
        }

        public async Task<ResponseDto> UpdateCouponsAsync(CouponDto couponDto)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.HttpMethodType.PUT,
                Data = couponDto,
                URL = SD.CouponAPIBase + "/api/coupon"
            });
        }
    }
}
