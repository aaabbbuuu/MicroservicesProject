using System.Threading.Tasks;
using Grpc.Core;
using Microsoft.Extensions.Logging;

namespace ProductService.Services
{
    public class ProductService : Product.ProductBase
    {
        private readonly ILogger<ProductService> _logger;

        public ProductService(ILogger<ProductService> logger)
        {
            _logger = logger;
        }

        public override Task<ProductReply> GetProduct(ProductRequest request, ServerCallContext context)
        {
            // Mock data for demonstration
            var product = new ProductReply
            {
                Id = request.Id,
                Name = "Sample product",
                Price = 49.99f
            };

            return Task.FromResult(product);
        }
    }
}
