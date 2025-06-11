using AutoMapper;
using Mango.Services.CouponAPI.Data;
using Mango.Services.CouponAPI.Models;
using Mango.Services.CouponAPI.Models.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Mango.Services.CouponAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CouponAPIController(AppDbContext _appDbContext, IMapper _mapper) : ControllerBase
    {

        [HttpGet]
        public ResponseDto<IEnumerable<CouponDto>> Get()
        {
            var response = new ResponseDto<IEnumerable<CouponDto>>();
            try
            {
                response.Result = _mapper
                    .Map<IEnumerable<CouponDto>>(_appDbContext.Coupons.ToList());
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
        public ResponseDto<CouponDto> Get(int id)
        {
            var response = new ResponseDto<CouponDto>();

            try
            {
                response.Result = _mapper.Map<CouponDto>(_appDbContext.Coupons.First(x => x.CouponId == id));
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }
            return response;

        }

        [HttpGet]
        [Route("GetByCode/{code}")]
        public ResponseDto<CouponDto> GetByCode(string code)
        {
            var response = new ResponseDto<CouponDto>();

            try
            {
                var coupon = _appDbContext.Coupons.First(x => x.CouponCode.ToLower().Equals(code.ToLower()));
                response.Result = _mapper.Map<CouponDto>(coupon);
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }
            return response;

        }

        [HttpPost]
        public ResponseDto<CouponDto> Post([FromBody] CouponDto couponDto)
        {
            var response = new ResponseDto<CouponDto>();

            try
            {
                var coupon = _mapper.Map<Coupon>(couponDto);
                _appDbContext.Coupons.Add(coupon);
                _appDbContext.SaveChanges();
                response.Result = _mapper.Map<CouponDto>(coupon);
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }
            return response;

        }

        [HttpPut]
        public ResponseDto<CouponDto> Update([FromBody] CouponDto couponDto)
        {
            var response = new ResponseDto<CouponDto>();

            try
            {
                var coupon = _mapper.Map<Coupon>(couponDto);
                _appDbContext.Coupons.Update(coupon);
                _appDbContext.SaveChanges();
                response.Result = _mapper.Map<CouponDto>(coupon);
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }
            return response;

        }

        [HttpDelete]
        public ResponseDto<string> Delete(int id)
        {
            var response = new ResponseDto<string>();

            try
            {
                var coupon = _appDbContext.Coupons.Find(id);
                if (coupon == null) throw new Exception("CouponId invalid");
                _appDbContext.Coupons.Remove(coupon);
                response.Result = "Deleted successfully";
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
