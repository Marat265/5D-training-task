using Microsoft.EntityFrameworkCore;
using OrderService.Data;
using OrderService.Services;
using ProductServiceClient;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddGrpc();


builder.Services.AddDbContext<OrderDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddGrpcClient<ProductServicee.ProductServiceeClient>(o =>
{
    o.Address = new Uri("http://localhost:5047"); 
});

var app = builder.Build();

app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

app.MapGrpcService<OrderGrpcService>();

app.Run();
