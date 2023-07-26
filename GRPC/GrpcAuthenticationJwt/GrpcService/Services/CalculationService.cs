using Grpc.Core;
using GrpcService;
using Microsoft.AspNetCore.Authorization;

namespace GrpcService.Services
{
    [Authorize]

    public class CalculationService : Calculation.CalculationBase
    {
        ILogger<CalculationService> logger;

        public CalculationService(ILogger<CalculationService> logger)
        {
            this.logger = logger;
        }

        public override Task<CalculationResult> Add(InputNumbers request, ServerCallContext context)
        {
            return Task.FromResult(new CalculationResult { Result = request.Number1 + request.Number2 });
        }

        [Authorize(Roles = "User")]
        public override Task<CalculationResult> Subtract(InputNumbers request, ServerCallContext context)
        {
            return Task.FromResult(new CalculationResult { Result = request.Number1 - request.Number2 });

        }

        [Authorize(Roles = "Admin")]

        public override Task<CalculationResult> Multiply(InputNumbers request, ServerCallContext context)
        {
            return Task.FromResult(new CalculationResult { Result = request.Number1 * request.Number2 });

        }
    }
}