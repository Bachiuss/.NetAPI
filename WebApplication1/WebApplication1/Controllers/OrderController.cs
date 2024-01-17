using Domain;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace WebApplication1.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderservice;

        public OrderController(IOrderService orderservice)
        {
            _orderservice = orderservice;
        }

        // Get all Orders
        [HttpGet("/orders")]
        public async Task<List<Order>> GetAllOrder()
        {
            return await _orderservice.GetAllOrders();
        }

        // Get A order by id
        [HttpGet("/order/{id}")]
        public async Task<Order> GetProductById(int id)
        {
            return await _orderservice.GetOrderById(id);
        }

        // Get a product by OrderID

        [HttpGet("/products/Order/{id}")]
        public async Task<List<Order>> GetProductsByCategoryId(int id)
        {
            return await _orderservice.GetOrdersByCustomer(id);
        }

        //Get total price of all products by Category IDs

        [HttpGet("/products/prices")]
        public async Task<List<Decimal>> GetTotalPriceOrdersForEachCustomer()
        {
            return await _orderservice.GetTotalPriceOrdersForEachCustomer();
        }

        // GetTotalPriceOfOrderWithCustomer
        [HttpGet("/order/prices/customer/{id}")]
        public async Task<Decimal> GetTotalPriceOfOrderWithCustomer(int id)
        {
            return await _orderservice.GetTotalPriceOfOrderWithCustomer(id);
        }

        // add new order
        [HttpPost("/order")]
        public async Task<Order> AddProduct([FromBody] Order order)
        {
            return await _orderservice.AddOrder(order);
        }

        // update order by order
        [HttpPut("/order/{id}")]
        public Order UpdateProduct(int id, [FromBody] Order order)
        {
            return _orderservice.UpdateOrder(id, order);
        }

        // Delete order by Id
        [HttpDelete("/products/{id}")]
        public Order DeleteOrderById(int id)
        {
            return _orderservice.DeleteOrder(id);
        }
    }
}
