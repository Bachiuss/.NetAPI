using Domain;

namespace Services
{
    public interface IOrderService
    {
        public Task<List<Order>> GetAllOrders();

        public Task<Order> GetOrderById(int id);

        public Task<Order> AddOrder(Order order);

        public Order UpdateOrder(int id, Order order);

        public Order DeleteOrder(int id);

        public Task<List<Order>> GetOrdersByCustomer(int customerId);

        public Task<Decimal> GetTotalPriceOfOrderWithCustomer(int customerId);
        public Task<List<Decimal>> GetTotalPriceOrdersForEachCustomer();
    }
}
