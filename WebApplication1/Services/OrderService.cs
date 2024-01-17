using Data;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Services
{
    public class OrderService : IOrderService
    {

        private readonly AppDbContext _context;

        public OrderService(AppDbContext context)
        {
            _context = context;
        }

        public async  Task<Order> AddOrder(Order order)
        {
            await _context.orders.AddAsync(order);
            await _context.SaveChangesAsync();
            return order;
        }

        public Order DeleteOrder(int id)
        {
            var Order = _context.orders.FirstOrDefault(o => o.Id == id);
            if (Order != null)
            {
                _context.orders.Remove(Order);
                _context.SaveChanges();
                return Order;
            }
            throw new OrderException("Not found !!");
            // vaketeb class
        }

        public async Task<List<Order>> GetAllOrders()
        {
            return await _context.orders.ToListAsync();
        }

        public async Task<Order> GetOrderById(int id)
        {
            var Order = await _context.orders.FirstOrDefaultAsync(o => o.Id == id);
            if (Order != null)
            {
                return Order;
            }
            throw new OrderException("Not found !!");
        }

        public async Task<List<Order>> GetOrdersByCustomer(int customerId)
        {
            return await _context.orders.Where(x => x.CustomerId == customerId).ToListAsync();
           
        }

        public async Task<decimal> GetTotalPriceOfOrderWithCustomer(int customerId)
        {
            return await _context.orders.Where(x => x.CustomerId == customerId).SumAsync(x => x.Price);
        }

        public async Task<List<decimal>> GetTotalPriceOrdersForEachCustomer()
        {
            return await _context.orders.GroupBy(x => x.CustomerId).Select(x => x.Sum(p => p.Price)).ToListAsync();
        }

        public Order UpdateOrder(int id, Order order)
        {
            var fnOrder = _context.orders.FirstOrDefault(x => x.Id == id);

            if (fnOrder != null)
            {
                fnOrder.Product = order.Product;
                fnOrder.Price = order.Price;
                _context.SaveChanges();
                return fnOrder;
            }
            throw new OrderException("Not found !!");
        }
    }
}
