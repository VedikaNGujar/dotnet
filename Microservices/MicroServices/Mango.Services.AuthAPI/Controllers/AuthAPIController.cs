using Mango.Services.AuthAPI.Models.Dto;
using Mango.Services.AuthAPI.Services.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Mango.Services.AuthAPI.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthAPIController(IAuthService authService) : ControllerBase
    {

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequestDto loginRequestDto)
        {
            var responseDto = new ResponseDto();
            var response = await authService.Login(loginRequestDto);
            if (response == null)
            {
                responseDto.Message = "User or Password is incorrect";
                responseDto.IsSuccess = false;
                return BadRequest(responseDto);
            }
            responseDto.Result = response;
            return Ok(response);
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegistrationRequestDto requestDto)
        {
            var responseDto = new ResponseDto() { IsSuccess = true, Message = "User registered successfully" };
            var response = await authService.Register(requestDto);
            if (!string.IsNullOrEmpty(response))
            {
                responseDto.Message = response;
                responseDto.IsSuccess = false;
                return BadRequest(responseDto);
            }

            return Ok(responseDto);

        }
    }
}
