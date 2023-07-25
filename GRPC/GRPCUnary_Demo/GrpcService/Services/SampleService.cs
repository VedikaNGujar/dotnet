using Grpc.Core;

namespace GrpcService.Services
{
    public class SampleService : Sample.SampleBase
    {
        private readonly ILogger<SampleService> _logger;
        public SampleService(ILogger<SampleService> logger)
        {
            _logger = logger;
        }

        public override Task<SampleResponse> GetFullName(SampleRequest request, ServerCallContext context)
        {
            return Task.FromResult(new SampleResponse
            {
                FullName = $"Hello {request.FirstName} {request.LastName}"
            });
        }
    }
}
