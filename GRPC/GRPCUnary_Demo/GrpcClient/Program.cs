// See https://aka.ms/new-console-template for more information
using Grpc.Net.Client;
using GrpcService;

Console.WriteLine("Hello, World!");

var channel = GrpcChannel.ForAddress("http://localhost:5000");
var client = new Sample.SampleClient(channel);

Console.WriteLine(client.GetFullName(
    new SampleRequest
    {
        FirstName = "Vedika",
        LastName = "Gujar"
    }));


Console.WriteLine(await client.GetFullNameAsync(
    new SampleRequest
    {
        FirstName = "Vedika",
        LastName = "Gujar"
    }));



// Product 

var productClient = new Product.ProductClient(channel);

Console.WriteLine(productClient.SaveProduct(
    new ProductModel
    {
        IsActive = true,
        Price = 32.32,
        ProductCode = "SamsungProduct X123",
        ProductName = "Mobile"
    }));


foreach (var product in productClient.GetProducts(new Google.Protobuf.WellKnownTypes.Empty()).Products)
{
    Console.WriteLine(
                $"{product.ProductCode} | " +
                $"{product.ProductCode} | " +
                $" {product.Price} | " +
                $" {product.StockDate} | " +
                $" {product.IsActive}");
}

await channel.ShutdownAsync();


