using Grpc.Core;
using GrpcService;

namespace GrpcService.Services
{
    public class StreamDemoService : StreamDemo.StreamDemoBase
    {
        private readonly ILogger<StreamDemoService> _logger;
        public StreamDemoService(ILogger<StreamDemoService> logger)
        {
            _logger = logger;
        }

        public override async Task ServerStreamingDemo(Test request, IServerStreamWriter<Test> responseStream, ServerCallContext context)
        {
            for (int i = 0; i < 20; i++)
            {
                await responseStream.WriteAsync(new Test() { TestMessage = $"Message {i}" });
                await Task.Delay(2000);
            }
        }
    }
}