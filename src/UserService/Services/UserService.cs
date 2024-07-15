using System.Threading.Tasks;
using Grpc.Core;
using Microsoft.Extensions.Logging;

namespace UserService.Services
{
    public class UserService : User.UserBase
    {
        private readonly ILogger<UserService> _logger;

        public UserService(ILogger<UserService> logger)
        {
            _logger = logger;
        }

        public override Task<UserReply> GetUser(UserRequest request, ServerCallContext context)
        {
            // Mock data for demonstration
            var user = new UserReply
            {
                Id = request.Id,
                Name = "Sample user",
                Email = "user@example.com"
            };

            return Task.FromResult(user);
        }
    }
}
