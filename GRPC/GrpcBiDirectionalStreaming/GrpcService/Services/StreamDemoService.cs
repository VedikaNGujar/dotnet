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

        public override async Task BiDirectionalStreaming(IAsyncStreamReader<Test> requestStream, IServerStreamWriter<Test> responseStream, ServerCallContext context)
        {
            var tasks = new List<Task>();

            while (await requestStream.MoveNext())
            {
                string message = requestStream.Current.TestMessage;
                await Task.Delay(1000);
                tasks.Add(Task.Run(async () =>
                {
                    await responseStream.WriteAsync(new Test() { TestMessage = message });
                    Console.WriteLine($"Hey Recieved Message : {message}");
                }));
            }
            await Task.WhenAll(tasks);
            Console.WriteLine($"Bidirectional Streaming from server completed");

        }
    }
}