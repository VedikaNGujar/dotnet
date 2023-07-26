using Grpc.Core;
using GrpcService2;

namespace GrpcService2.Services
{
    public class SubtractService : Subtract.SubtractBase
    {
        private readonly ILogger<SubtractService> _logger;
        public SubtractService(ILogger<SubtractService> logger)
        {
            _logger = logger;
        }

        public override async Task<CalculationResponse> Subtract(CalculationRequest request, ServerCallContext context)
        {
            await Task.Delay(8000);


            return await Task.FromResult(new CalculationResponse
            {
                Result = request.Number1 - request.Number2
            });
        }

    }
}