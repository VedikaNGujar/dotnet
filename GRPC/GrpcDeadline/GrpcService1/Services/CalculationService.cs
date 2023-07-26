using Grpc.Core;
using Grpc.Net.Client;
using GrpcService1;
using GrpcService2;

namespace GrpcService1.Services
{
    public class CalculationService : Calculation.CalculationBase
    {
        private readonly ILogger<CalculationService> _logger;
        public CalculationService(ILogger<CalculationService> logger)
        {
            _logger = logger;
        }

        public override async Task<CalculationResponse> Sum(CalculationRequest request, ServerCallContext context)
        {
            await Task.Delay(5000);

            return await Task.FromResult(new CalculationResponse
            {
                Result = request.Number1 + request.Number2
            });
        }

        public override async Task<CalculationResponse> Subtract(CalculationRequest request, ServerCallContext context)
        {

            var channel = GrpcChannel.ForAddress("http://localhost:5174");
            var subClient = new Subtract.SubtractClient(channel);
            var subResponse = await subClient.SubtractAsync(new GrpcService2.CalculationRequest
            {
                Number1 = request.Number1,
                Number2 = request.Number2
            }, deadline: context.Deadline);
            return await Task.FromResult(new CalculationResponse { Result = subResponse.Result });
        }
    }
}