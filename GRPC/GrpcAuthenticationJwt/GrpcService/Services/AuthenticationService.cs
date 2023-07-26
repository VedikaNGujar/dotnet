using Grpc.Core;
using GrpcService;
using Microsoft.AspNetCore.Authorization;

namespace GrpcService.Services
{
    public class AuthenticationService : Authentication.AuthenticationBase
    {
        ILogger<AuthenticationService> logger;

        public AuthenticationService(ILogger<AuthenticationService> logger)
        {
            this.logger = logger;
        }

        public override async Task<AuthenticationResponse> Authenticate(AuthenticationRequest request, ServerCallContext context)
        {
            var authenticationResponse = JwtAuthenticationManager.Authenticate(request);
            if (authenticationResponse is null)
            {
                throw new RpcException(new Status(StatusCode.Unauthenticated, "Invalid user credentials"));
            }
            return authenticationResponse;
        }
    }
}