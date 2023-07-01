using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Options;
using System.Security.Claims;
using System.Security.Principal;
using System.Text.Encodings.Web;

namespace JWTApproach3.Services
{
    public class BasicAuthenticationOptions : AuthenticationSchemeOptions
    {

    }
    public class CustomAuthenticationHandler : AuthenticationHandler<BasicAuthenticationOptions>
    {
        private readonly ICustomAuthenticationManager customAuthenticationManager;

        public CustomAuthenticationHandler(
            IOptionsMonitor<BasicAuthenticationOptions> options,
            ILoggerFactory logger,
            UrlEncoder encoder, ISystemClock clock, ICustomAuthenticationManager customAuthenticationManager) : base(options, logger, encoder, clock)
        {
            this.customAuthenticationManager = customAuthenticationManager;
        }

        protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            try
            {
                if (!Request.Headers.ContainsKey("Authorization"))
                    return AuthenticateResult.Fail("Unauthorized");

                string authorizationHeader = Request.Headers["Authorization"];
                if (string.IsNullOrEmpty(authorizationHeader))
                    return AuthenticateResult.Fail("Unauthorized");

                if (!authorizationHeader.StartsWith("bearer", StringComparison.OrdinalIgnoreCase))
                    return AuthenticateResult.Fail("Unauthorized");


                string token = authorizationHeader.Substring("bearer".Length).Trim();
                if (string.IsNullOrEmpty(token))
                    return AuthenticateResult.Fail("Unauthorized");

                return ValidateToken(token);
            }
            catch (Exception ex)
            {
                return AuthenticateResult.Fail(ex.Message);
            }
        }

        private AuthenticateResult ValidateToken(string token)
        {
            if (!customAuthenticationManager.Tokens.TryGetValue(token, out var userName))
            {
                return AuthenticateResult.Fail("Unauthorized");
            }
            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, userName.Item1),
                new Claim(ClaimTypes.Role, userName.Item2)
            };

            var identity = new ClaimsIdentity(claims, Scheme.Name);
            var principal = new GenericPrincipal(identity, new[] { userName.Item2 });
            var ticket = new AuthenticationTicket(principal, Scheme.Name);
            return AuthenticateResult.Success(ticket);


        }
    }
}
