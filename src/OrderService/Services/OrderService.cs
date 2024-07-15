using System.Threading.Tasks;
using Grpc.Core;
using Microsoft.Extensions.Logging;

namespace OrderService.Services
{
    public class OrderService : Order.OrderBase
    {
        private readonly ILogger<OrderService> _logger;

        public OrderService(ILogger<OrderService> logger)
        {
            _logger = logger;
        }

        public override Task<OrderReply> GetOrder(OrderRequest request, ServerCallContext context)
        {
            // Mock data for demonstration
            var order = new OrderReply
            {
                Id = request.Id,
                Description = "Sample order",
                Price = 99.99f
            };

            return Task.FromResult(order);
        }
    }
}
