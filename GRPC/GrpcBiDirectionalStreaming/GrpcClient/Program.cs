using Grpc.Net.Client;
using GrpcService;

internal class Program
{
    private static void Main(string[] args)
    {
        BiDirectionalStreamingDemo().GetAwaiter().GetResult();
    }

    private static async Task BiDirectionalStreamingDemo()
    {
        var channel = GrpcChannel.ForAddress("http://localhost:5058");
        var client = new StreamDemo.StreamDemoClient(channel);
        var stream = client.BiDirectionalStreaming();

        var requestTasks = Task.Run(async () =>
        {
            for (int i = 0; i < 10; i++)
            {
                var message = $"Sending Message from Client {i}";
                await stream.RequestStream.WriteAsync(new Test { TestMessage = message });
                Console.WriteLine(message);
                await Task.Delay(1000);
            }
            await stream.RequestStream.CompleteAsync();
        });

        var responseTask = Task.Run(async () =>
        {
            while (await stream.ResponseStream.MoveNext(CancellationToken.None))
            {
                var message = $"Received from Server: {stream.ResponseStream.Current.TestMessage}";
                Console.WriteLine(message);
            }
        });

        await Task.WhenAll(requestTasks, responseTask);
    }
}