using JWTApproach2.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace JWTApproach2.Services
{
    public interface ITokenRefresher
    {

        public AuthenticationResponse Refresh(RefreshCred refreshCred);
    }
}