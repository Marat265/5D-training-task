using Grpc.Core;
using Microsoft.EntityFrameworkCore;
using OrderService.Data;
using ProductServiceClient;

namespace OrderService.Services
{
    public class OrderGrpcService:OrderServicee.OrderServiceeBase
    {
        private readonly OrderDbContext _dbContext;
        private readonly ProductServicee.ProductServiceeClient _productClient;

        public OrderGrpcService(OrderDbContext dbContext, ProductServicee.ProductServiceeClient product)
        {
            _dbContext = dbContext;
            _productClient = product;
        }

        public override async Task<OrderResponse> CreateOrder(CreateOrderrRequest request, ServerCallContext context)
        {
            var product = await _productClient.GetProductAsync(new ProductRequest { Id = request.ProductId });

            if (product == null || product.Stock < request.Quantity)
            {
                throw new RpcException(new Status(StatusCode.FailedPrecondition, "Недостаточно товара на складе"));
            }

            await _productClient.UpdateStockAsync(new UpdateStockRequest
            {
                Id = request.ProductId,
                NewStock = product.Stock - request.Quantity,
            });

            var order = new Order
            {
                ProductId = request.ProductId,
                Quantity = request.Quantity,
                TotalPrice = product.Price * request.Quantity
            };

            _dbContext.Orders.Add(order);
            await _dbContext.SaveChangesAsync();

            return new OrderResponse
            {
                Id = order.Id,
                ProductId = order.ProductId,
                Quantity = order.Quantity,
                TotalPrice = order.TotalPrice
            };

        }

        public override async Task<OrderResponse> GetOrder(OrderRequest request, ServerCallContext context)
        {
            var order = await _dbContext.Orders.FirstOrDefaultAsync(o => o.Id == request.Id);

            if (order == null)
            {
                throw new RpcException(new Status(StatusCode.NotFound, "Заказ не найден"));
            }

            return new OrderResponse
            {
                Id = order.Id,
                ProductId = order.ProductId,
                Quantity = order.Quantity,
                TotalPrice = order.TotalPrice
            };
        }
    }
}
