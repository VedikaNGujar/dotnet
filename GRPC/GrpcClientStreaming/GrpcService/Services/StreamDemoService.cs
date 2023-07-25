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

        public override async Task<Test> ClientStreamingDemo(IAsyncStreamReader<Test> requestStream, ServerCallContext context)
        {
            while (await requestStream.MoveNext())
            {
                Console.WriteLine(requestStream.Current.TestMessage);
            }

            Console.WriteLine("Client Streaming Completed!");
            return new Test()
            {
                TestMessage = "Completed"
            };
        }

    }
}