using Grpc.Core;
using Microsoft.EntityFrameworkCore;
using ProductService.Data;

namespace ProductService.Services
{
    public class ProductGrpcService: ProductServicee.ProductServiceeBase
    {
        private readonly ProductDbContext _dbcontext;

        public ProductGrpcService(ProductDbContext dbContext)
        {
            _dbcontext = dbContext;
        }

        public override async Task<ProductResponse> GetProduct(ProductRequest request, ServerCallContext context)
        {
            var product = await _dbcontext.Products.FirstOrDefaultAsync(p => p.Id == request.Id);

            if(product == null)
                throw new RpcException(new Status(StatusCode.NotFound, "Продукт не найден"));

            return new ProductResponse
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                Stock = product.Stock
            };
        }


        public override async Task<ProductResponse> AddProduct(AddProductRequest request, ServerCallContext context)
        {
            var newProduct = new Product
            {
                Name = request.Name,
                Price = request.Price,
                Stock = request.Stock
            };

            _dbcontext.Products.Add(newProduct);
            await _dbcontext.SaveChangesAsync();

            return new ProductResponse
            {
                Id = newProduct.Id,
                Name = newProduct.Name,
                Price = newProduct.Price,
                Stock = newProduct.Stock
            };
        }


        public override async Task<StockResponse> UpdateStock(UpdateStockRequest request, ServerCallContext context)
        {
            var product = await _dbcontext.Products.FirstOrDefaultAsync(p => p.Id == request.Id);

            if (product==null)
            {
                return new StockResponse { Success = false };
            }

            product.Stock = request.NewStock;
            await _dbcontext.SaveChangesAsync();

            return new StockResponse { Success = true };
        }


    }
}
