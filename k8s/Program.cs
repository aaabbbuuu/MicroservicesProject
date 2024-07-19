using System;
using Grpc.Net.Client;
using OrderService;

class Program
{
    static async Task Main(string[] args)
    {
        // The port number must match the port of the gRPC server.
        using var channel = GrpcChannel.ForAddress("http://localhost:5000");
        var client = new Order.OrderClient(channel);

        var reply = await client.GetOrderAsync(new OrderRequest { Id = 1 });
        Console.WriteLine("Order Description: " + reply.Description);
    }
}
