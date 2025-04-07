using Grpc.Net.Client;
using ProductService;
using OrderService;

class Program
{
    static async Task Main(string[] args)
    {
        using var productChannel = GrpcChannel.ForAddress("http://localhost:5047");
        var productClient = new ProductServicee.ProductServiceeClient(productChannel);

        var createResponse = await productClient.AddProductAsync(new AddProductRequest
        {
            Name = "Банан",
            Price = 20,
            Stock = 10
        });

        Console.WriteLine();

        var product = await productClient.GetProductAsync(new ProductRequest { Id = createResponse.Id });

        Console.WriteLine($"ваш продукт - {product}");


        Console.Write("Введите новое количество стоков - ");
        int newStock = Int32.Parse( Console.ReadLine() );

        var isChange = await productClient.UpdateStockAsync(new UpdateStockRequest { Id = createResponse.Id, NewStock = newStock });

        if (isChange.Success)
        {
            var updateProduct = await productClient.GetProductAsync(new ProductRequest { Id = createResponse.Id });
            Console.WriteLine($"Вы успешно обновили продукт - {updateProduct}");
        }



        using var orderChannel = GrpcChannel.ForAddress("http://localhost:5279");
        var orderClient = new OrderServicee.OrderServiceeClient(orderChannel);

        var orderResponse = await orderClient.CreateOrderAsync(new CreateOrderrRequest
        {
            ProductId = createResponse.Id,
            Quantity = 2
        });


        var orderInfo = await orderClient.GetOrderAsync(new OrderRequest { Id = orderResponse.Id });
        Console.WriteLine($"Получен заказ: {orderInfo}");


        var stockChangeProduct = await productClient.GetProductAsync(new ProductRequest { Id = createResponse.Id });
        Console.WriteLine($"Продукт после выполнения заказа - {stockChangeProduct}");

    }
}
