using Mango.Services.AuthAPI.Data;
using Mango.Services.AuthAPI.Models;
using Mango.Services.AuthAPI.Models.Dto;
using Mango.Services.AuthAPI.Services.IServices;
using Microsoft.AspNetCore.Identity;

namespace Mango.Services.AuthAPI.Services
{
    public class AuthService(AppDbContext appDbContext,
        UserManager<ApplicationUser> userManager,
        RoleManager<IdentityRole> roleManager) : IAuthService
    {
        private readonly AppDbContext appDbContext = appDbContext;
        private readonly UserManager<ApplicationUser> userManager = userManager;
        private readonly RoleManager<IdentityRole> roleManager = roleManager;

        public Task<bool> AssignRole(string email, string roleName)
        {
            throw new NotImplementedException();
        }

        public async Task<LoginResponseDto> Login(LoginRequestDto loginRequestDto)
        {
            var user = appDbContext
                 .ApplicationUsers
                 .FirstOrDefault(u => u.UserName.ToLower().Equals(loginRequestDto.UserName.ToLower()));

            if (!await userManager.CheckPasswordAsync(user, loginRequestDto.Password))
            {
                return null;
            }

            return new LoginResponseDto()
            {
                User = new UserDto()
                {
                    Email = user.Email,
                    ID = user.Id,
                    Name = user.Name,
                    PhoneNumber = user.PhoneNumber
                },
                Token = ""
            };

        }

        public async Task<string> Register(RegistrationRequestDto registrationRequestDto)
        {
            var user = new ApplicationUser()
            {
                UserName = registrationRequestDto.Email,
                Email = registrationRequestDto.Email,
                PhoneNumber = registrationRequestDto.PhoneNumber,
                Name = registrationRequestDto.Name,
                NormalizedEmail = registrationRequestDto.Email.ToUpper()
            };

            try
            {
                var result = await userManager.CreateAsync(user, registrationRequestDto.Password);
                return result.Succeeded ? "" : result.Errors?.FirstOrDefault()?.Description;
            }
            catch (Exception ex)
            {

                return ex.Message;
            }


        }
    }
}
