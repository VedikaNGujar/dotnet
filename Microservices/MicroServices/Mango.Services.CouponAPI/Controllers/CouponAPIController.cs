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
    }
}
