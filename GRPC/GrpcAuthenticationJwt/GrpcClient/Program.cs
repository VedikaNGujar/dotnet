using Grpc.Core;
using Grpc.Net.Client;
using GrpcService;

internal class Program
{
    private static async Task Main(string[] args)
    {
        await LoginAsync("user", "password");
        await LoginAsync("admin", "password");
        Console.ReadLine();
    }

    private static async Task LoginAsync(string username, string password)
    {
        try
        {
            var channel = GrpcChannel.ForAddress(" http://localhost:5152");
            var authClient = new Authentication.AuthenticationClient(channel);
            var authResponse = await authClient.AuthenticateAsync(new AuthenticationRequest
            {
                Password = password,
                UserName = username,
            });
            Console.WriteLine(authResponse);

            var calculationClient = new Calculation.CalculationClient(channel);
            var inputNumbers = new InputNumbers { Number1 = 20, Number2 = 4 };
            var headers = new Metadata();
            headers.Add(new Metadata.Entry("Authorization", $"Bearer {authResponse.JwtToken}"));

            var addResponse = calculationClient.Add(inputNumbers, headers);
            Console.WriteLine($"Add Result = {addResponse.Result}");

            var multiplyResponse = calculationClient.Multiply(inputNumbers, headers);
            Console.WriteLine($"Multiply Result = {addResponse.Result}");

            var subtractResponse = calculationClient.Subtract(inputNumbers, headers);
            Console.WriteLine($"Subtract Result = {addResponse.Result}");


            await channel.ShutdownAsync();
        }
        catch (RpcException ex)
        {
            Console.WriteLine($"Exception = {ex.Message}");
        }
    }
}