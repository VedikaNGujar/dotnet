using Azure;
using Mango.MessageBus;
using Mango.Services.AuthAPI.Models.Dto;
using Mango.Services.AuthAPI.Services;
using Mango.Services.AuthAPI.Services.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace Mango.Services.AuthAPI.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthAPIController(IAuthService authService, IMessageBus _messageBus, IConfiguration _configuration) : ControllerBase
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
            return Ok(responseDto);
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

            await _messageBus.PublishMessage(requestDto.Email, _configuration.GetValue<string>("TopicAndQueueNames:RegisterUserQueue"));

            return Ok(responseDto);

        }

        [HttpPost("AssignRole")]
        public async Task<IActionResult> AssignRole([FromBody] RegistrationRequestDto model)
        {
            var responseDto = new ResponseDto();

            var assignRoleSuccessful = await authService.AssignRole(model.Email, model.Role.ToUpper());
            if (!assignRoleSuccessful)
            {
                responseDto.IsSuccess = false;
                responseDto.Message = "Error encountered";
                return BadRequest(responseDto);
            }
            return Ok(responseDto);

        }
    }
}
