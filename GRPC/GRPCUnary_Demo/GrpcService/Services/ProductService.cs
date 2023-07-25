using Google.Protobuf.WellKnownTypes;
using Grpc.Core;

namespace GrpcService.Services
{
    public class ProductService : Product.ProductBase
    {
        public override Task<ProductSaveResponse> SaveProduct(ProductModel request, ServerCallContext context)
        {
            Console.WriteLine(
                $"{request.ProductCode} | " +
                $"{request.ProductCode} | " +
                $" {request.Price} | " +
                $" {request.StockDate} | " +
                $" {request.IsActive}");

            var result = new ProductSaveResponse()
            {
                IsSuccessful = true,
                StatusCode = 200
            };

            return Task.FromResult(result);
        }

        public override Task<ProductList> GetProducts(Empty request, ServerCallContext context)
        {

            var productList = new List<ProductModel>()
            {
                 new ProductModel
                    {
                        IsActive = true,
                        Price = 0,
                        ProductCode="x1234",
                        ProductName = "onePlus",
                        StockDate = DateTime.UtcNow.ToTimestamp(),
                    },
                    new ProductModel
                    {
                        IsActive = false,
                        Price = 100,
                        ProductCode="x14",
                        ProductName = "iPhone",
                        StockDate = DateTime.UtcNow.ToTimestamp(),
                    }
            };

            var products = new ProductList();
            products.Products.AddRange(productList);
            return Task.FromResult(products);
        }
    }
}
