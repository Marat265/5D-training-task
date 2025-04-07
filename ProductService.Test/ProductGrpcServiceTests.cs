using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using ProductService.Data;
using ProductService.Services;

namespace ProductService.Tests
{
    public class ProductGrpcServiceTests
    {
        private async Task<ProductDbContext> GetDatabaseContext()
        {
            var options = new DbContextOptionsBuilder<ProductDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;
            var databaseContext = new ProductDbContext(options);
            databaseContext.Database.EnsureCreated();

            if (await databaseContext.Products.CountAsync() <= 0)
            {

                    databaseContext.Products.Add(new Product
                    {
                        Name = $"Product {1}",
                        Price = 100 ,
                        Stock = 50
                    });

                await databaseContext.SaveChangesAsync();
            }
            return databaseContext;
        }


        [Fact]
        public async void GetProduct_ReturnProduct()
        {
            //Arrange
            var dbContext = await GetDatabaseContext();
            var productService = new ProductGrpcService(dbContext);
            var request = new ProductRequest { Id = 1 };

            //Act
            var response = await productService.GetProduct(request, null);

            //Assert
            response.Should().NotBeNull();
            response.Id.Should().Be(1);
            response.Name.Should().Be("Product 1");
            response.Price.Should().Be(100);
            response.Stock.Should().Be(50);
        }


        [Fact]
        public async void AddProduct_ReturnNewProduct()
        {
            //Arrange
            var dbContext = await GetDatabaseContext();
            var productService = new ProductGrpcService(dbContext);
            var request = new AddProductRequest { Name = "NewProduct", Price = 200, Stock = 60 };

            //Act
            var response = await productService.AddProduct(request, null);

            //Assert
            response.Should().NotBeNull();
            response.Name.Should().Be("NewProduct");
            response.Price.Should().Be(200);
            response.Stock.Should().Be(60);
        }


        [Fact]
        public async void UpdateStock_ReturnSuccess()
        {
            //Arrange
            var dbContext = await GetDatabaseContext();
            var productService = new ProductGrpcService(dbContext);
            var request = new UpdateStockRequest { Id = 1, NewStock = 20 };
            var productAfterUpdate = await dbContext.Products.FirstOrDefaultAsync(p => p.Id == 1);

            //Act
            var response = await productService.UpdateStock(request, null);

            //Assert
            response.Should().NotBeNull();
            productAfterUpdate.Stock.Should().Be(20);
            response.Success.Should().BeTrue();
        }
    }
}