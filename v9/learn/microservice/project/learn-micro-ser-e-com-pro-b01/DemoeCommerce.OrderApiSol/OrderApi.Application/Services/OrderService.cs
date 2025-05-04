using OrderApi.Application.Dtos;
using OrderApi.Application.Dtos.Conversions;
using OrderApi.Application.Interfaces;
using Polly;
using Polly.Registry;
using System.Net.Http.Json;

namespace OrderApi.Application.Services
{
    public class OrderService(IOrder orderInterface, HttpClient httpClient, ResiliencePipelineProvider<string> resiliencePipeline) : IOrderService
    {

        // GET PRODUCT 
        public async Task<ProductDto> GetProduct(int productId)
        {
            // call product api  using HttpClient
            // Redirect this call to the API Gateway since product API is not response to outsiders.
            var getProduct = await httpClient.GetAsync($"/api/product/{productId}");
            if (!getProduct.IsSuccessStatusCode)
            {
                return null!;
            }

            var product = await getProduct.Content.ReadFromJsonAsync<ProductDto>();
            return product!;
        }

        //  GET USER
        public async Task<AppUserDto> GetUser(int userId)
        {
            // call product api  using HttpClient
            // Redirect this call to the API Gateway since product API is not response to outsiders.
            var getUser = await httpClient.GetAsync($"/api/user/{userId}");
            if (!getUser.IsSuccessStatusCode)
            {
                return null!;
            }

            var user = await getUser.Content.ReadFromJsonAsync<AppUserDto>();
            return user!;
        }

        // GET ORDER DETAILS BY ID
        public async Task<OrderDetailsDto> GetOrderDetails(int orderId)
        {
            // Prepare Order
            var order = await orderInterface.GetByIdAsync(orderId);
            if (order is null || order!.Id <= 0)
            {
                return null!;
            }

            // Get Retry pipeline
            var retryPipeline = resiliencePipeline.GetPipeline("my-retry-pipeline");

            // Prepare Product
            var productDto = await retryPipeline.ExecuteAsync(async token => await GetProduct(order.ProductId));

            // Prepare Client
            var appUserDto = await retryPipeline.ExecuteAsync(async token => await GetUser(order.ClientId));

            // Populate order details
            return new OrderDetailsDto(
                order.Id,
                productDto.Id,
                appUserDto.Id,
                appUserDto.Name,
                appUserDto.Email,
                appUserDto.Address,
                appUserDto.TelephoneNumber,
                productDto.Name,
                order.PurchaseQuantity,
                productDto.Price,
                productDto.Quantity * order.PurchaseQuantity,
                order.OrderedDate
                );
        }

        public async Task<IEnumerable<OrderDto>> GetOrdersByClientId(int clientId)
        {
            // GET all client's orders
            var orders = await orderInterface.GetOrdersAsync(o => o.ClientId == clientId);
            if (!orders.Any()) return null!;

            // Convert from Entity to dto
            var (_, listOrders) = OrderConversion.FromEntity(null, orders);

            return listOrders;
        }
    }
}
