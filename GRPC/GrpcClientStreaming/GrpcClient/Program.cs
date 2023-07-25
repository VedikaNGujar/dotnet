using Grpc.Net.Client;
using GrpcService;

internal class Program
{
    private static void Main(string[] args)
    {
        ClientStreamingDemo().GetAwaiter().GetResult();
    }

    private static async Task ClientStreamingDemo()
    {
        var channel = GrpcChannel.ForAddress("http://localhost:5000");
        var client = new StreamDemo.StreamDemoClient(channel);
        var stream = client.ClientStreamingDemo();

        for (int i = 0; i < 10; i++)
        {
            Console.WriteLine($"Sending Message {i}");

            await stream.RequestStream.WriteAsync(
                new Test()
                {
                    TestMessage = $"Message from client {i}"
                });

            await Task.Delay(1000);
        }

        await stream.RequestStream.CompleteAsync();
    }
}