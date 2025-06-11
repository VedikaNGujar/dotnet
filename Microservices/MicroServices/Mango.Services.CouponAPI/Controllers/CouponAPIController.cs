using Mango.Services.CouponAPI.Data;
using Mango.Services.CouponAPI.Models;
using Mango.Services.CouponAPI.Models.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Mango.Services.CouponAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CouponAPIController(AppDbContext _appDbContext) : ControllerBase
    {

        [HttpGet]
        public ResponseDto<IEnumerable<Coupon>> Get()
        {
            var response = new ResponseDto<IEnumerable<Coupon>>();
            try
            {
                response.Result = _appDbContext.Coupons.ToList();
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }
            return response;

        }

        [HttpGet]
        [Route("{id:int}")]
        public ResponseDto<Coupon> Get(int id)
        {
            var response = new ResponseDto<Coupon>();

            try
            {
                response.Result = _appDbContext.Coupons.First(x => x.CouponId == id);
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }
            return response;

        }
    }
}
