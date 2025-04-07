using OrderService.Data;
using OrderService;
using ProductServiceClient;
using FluentAssertions;
using FakeItEasy;
using Microsoft.EntityFrameworkCore;
using OrderService.Services;
using Grpc.Core;

namespace OrderServiceTests
{
    public class OrderGrpcServiceTests
    {
        private async Task<OrderDbContext> GetDatabaseContext()
        {
            var options = new DbContextOptionsBuilder<OrderDbContext>()
                 .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                 .Options;
            var databaseContext = new OrderDbContext(options);
            databaseContext.Database.EnsureCreated();

            if (await databaseContext.Orders.CountAsync() <= 0)
            {
                    databaseContext.Orders.Add(new Order
                    {
                        ProductId = 1,
                        Quantity = 1,
                        TotalPrice = 100
                    });
                await databaseContext.SaveChangesAsync();
            }

            return databaseContext;
        }


        [Fact]
        public async void CreateOrder_ShouldAddNewOrder_WhenStockIsAvailable()
        {
            //Arrange
            var dbContext = await GetDatabaseContext();
            var productServiceClient = A.Fake<ProductServicee.ProductServiceeClient>();
            var orderService = new OrderGrpcService(dbContext, productServiceClient);

            var request = new CreateOrderrRequest
            {
                ProductId = 1,
                Quantity = 5,
            };

            var productResponse = new ProductResponse
            {
                Id = 1,
                Name = "Test Product",
                Price = 100,
                Stock = 5
            };

            var asyncUnaryCall = Task.FromResult(productResponse);
            A.CallTo(() => productServiceClient.GetProductAsync(
                A<ProductRequest>.That.Matches(p => p.Id == 1),
                null, null, CancellationToken.None))
                .Returns(new AsyncUnaryCall<ProductResponse>(
                    asyncUnaryCall,
                    null,
                    null,
                    null,
                    null));


            A.CallTo(() => productServiceClient.UpdateStockAsync(
              A<UpdateStockRequest>.That.Matches(r => r.Id == 1 && r.NewStock == productResponse.Stock - request.Quantity),
              null, null, CancellationToken.None))
              .Returns(new AsyncUnaryCall<StockResponse>(
                  Task.FromResult(new StockResponse { Success = true }),
                  null,
                  null,
                  null,
                  null));

            //Act
            var response = await orderService.CreateOrder(request, null);

            //Assert
            response.Should().NotBeNull();
            response.ProductId.Should().Be(1);
            response.Quantity.Should().Be(5);
            response.TotalPrice.Should().Be(500);
        }


        [Fact]
        public async void GetOrder_ShouldReturnOrder()
        {
            //Arrange
            var dbContext = await GetDatabaseContext();
            var productServiceClient = A.Fake<ProductServicee.ProductServiceeClient>();
            var orderService = new OrderGrpcService(dbContext, productServiceClient);

            var request = new OrderRequest { Id = 1};
           
            //Act
            var response = await orderService.GetOrder(request, null);

            //Assert
            response.Should().NotBeNull();
            response.ProductId.Should().Be(1);
            response.Quantity.Should().Be(1);
            response.TotalPrice.Should().Be(100);
        }

    }
}