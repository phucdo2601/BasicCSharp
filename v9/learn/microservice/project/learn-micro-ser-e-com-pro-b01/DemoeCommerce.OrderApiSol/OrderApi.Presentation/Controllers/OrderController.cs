using eCommerce.SharedLibrary.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderApi.Application.Dtos;
using OrderApi.Application.Dtos.Conversions;
using OrderApi.Application.Interfaces;
using OrderApi.Application.Services;
using OrderApi.Domain.Entities;

namespace OrderApi.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController(IOrder orderInterface, IOrderService orderService) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderDto>>> GetOrders()
        {
            var orders = await orderInterface.GetAllAsync();
            if (!orders.Any())
            {
                return NotFound("No order detected in the database");
            }

            var(_, list) = OrderConversion.FromEntity(null, orders);
            if (!list!.Any())
            {
                return NotFound("No order detected in the database");
            }
            return Ok(list);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<OrderDto>> GetOrder(int id)
        {
            var order = await orderInterface.GetByIdAsync(id);
            if (order is null)
            {
                return NotFound("No product detached in the database");
            }

            var (_order, _) = OrderConversion.FromEntity(order, null);

            return _order is not null ? Ok(_order) : NotFound("No order found");
        }

        [HttpGet("client/{clientId}")]
        public async Task<ActionResult<OrderDto>> GetOrderByClientId([FromRoute(Name = "clientId")] int clientId)
        {
            if (clientId <= 0)
            {
                return BadRequest("Invalid data provided");
            }

            var orders = await orderInterface.GetOrdersAsync(o =>o.ClientId == clientId);
            return !orders.Any() ? Ok(orders) : NotFound("No orders found");
        }

        [HttpGet("details/{orderId}")]
        public async Task<ActionResult<OrderDto>> GetOrderByDetailId([FromRoute(Name = "orderId")] int orderId)
        {
            if (orderId <= 0)
            {
                return BadRequest("Invalid data provided");
            }

            var orders = await orderService.GetOrderDetails(orderId);
            return orders.OrderId > 0 ? Ok(orders) : NotFound("No orders found");
        }

        [HttpPost]
        public async Task<ActionResult<Response>> CreateOrder(OrderDto orderDto)
        {
            // Check model state is all data annotations are passed
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Convert to entity
            var getEntity = OrderConversion.ToEntity(orderDto);
            var response = await orderInterface.CreateAsync(getEntity);
            return response?.Flag is true ? Ok(response) : BadRequest(response);
        }

        [HttpPut]
        public async Task<ActionResult<Response>> UpdateOrder(OrderDto orderDto)
        {
            // Check model state is all data annotations are passed
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Convert to entity
            var getEntity = OrderConversion.ToEntity(orderDto);
            var response = await orderInterface.UpdateAsync(getEntity);
            return response?.Flag is true ? Ok(response) : BadRequest(response);
        }

        [HttpDelete]
        public async Task<ActionResult<Response>> DeleteProduct(OrderDto orderDto)
        {
            // Convert to entity
            var getEntity = OrderConversion.ToEntity(orderDto);
            var response = await orderInterface.DeleteAsync(getEntity);
            return response?.Flag is true ? Ok(response) : BadRequest(response);
        }
    }
}
