using Grpc.Net.Client;
using GrpcService1;

internal class Program
{
    private static async Task Main(string[] args)
    {
        try
        {
            var channel = GrpcChannel.ForAddress("http://localhost:5272");
            var client = new Calculation.CalculationClient(channel);

            var sumWithoutDeadlineRes = await client.SumAsync(
              new CalculationRequest
              {
                  Number1 = 1009,
                  Number2 = 30
              });
            Console.WriteLine($"Sum Without Deadline : {sumWithoutDeadlineRes}");


            //var sumWithDeadlineRes = await client.SumAsync(
            //    new CalculationRequest
            //    {
            //        Number1 = 1009,
            //        Number2 = 30
            //    }, deadline: DateTime.UtcNow.AddSeconds(1));
            //Console.WriteLine($"Sum With Deadline  : {sumWithDeadlineRes}");



            var subtractRes = await client.SubtractAsync(
               new CalculationRequest
               {
                   Number1 = 1009,
                   Number2 = 30
               });
            Console.WriteLine($"Subtract Without Deadline : : {subtractRes}");

            var subtractResWithDeadline = await client.SubtractAsync(
             new CalculationRequest
             {
                 Number1 = 1009,
                 Number2 = 30
             }, deadline: DateTime.UtcNow.AddSeconds(3000));
            Console.WriteLine($"Subtract With Deadline : : {subtractRes}");

            await channel.ShutdownAsync();


        }
        catch (Exception ex)
        {
            Console.WriteLine($"Exception : {ex.Message}");
        }

        Console.Read();
        Console.Read();
    }
}