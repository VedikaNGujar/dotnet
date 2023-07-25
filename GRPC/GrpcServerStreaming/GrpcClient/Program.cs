// See https://aka.ms/new-console-template for more information
using Grpc.Core;
using Grpc.Net.Client;
using GrpcService;

internal class Program
{
    private static void Main(string[] args)
    {

        ServerStreamingDemo().GetAwaiter().GetResult();
    }

    private static async Task ServerStreamingDemo()
    {
        var channel = GrpcChannel.ForAddress("http://localhost:5000");
        var client = new StreamDemo.StreamDemoClient(channel);

        var response = client.ServerStreamingDemo(new Test { TestMessage = "Hello" });

        while (await response.ResponseStream.MoveNext(CancellationToken.None))
        {
            var value = response.ResponseStream.Current.TestMessage;
            Console.WriteLine(value);
        }

        Console.WriteLine("Server Streaming Completed");
        await channel.ShutdownAsync();
    }
}