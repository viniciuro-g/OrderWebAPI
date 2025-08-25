using BudgetWebAPI.Data;
using BudgetWebAPI.Models.Enum;
using BudgetWebAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using OrderWebAPI.Models.Entities;

namespace BudgetWebAPI.Repositories.Implementation
{
    public class OrderRepository : IOrderRepository
    {
        private readonly AppDbContext _context;

        public OrderRepository(AppDbContext context)
        {
            _context = context;
        }


        public async Task<Order> CreateOrderAsync(Order order)
        {
            await _context.AddAsync(order);
            await _context.SaveChangesAsync();
            return order;
        }

        public async Task DeleteOrderAsync(int id)
        {
            var dataBaseOrder = await _context.Orders.FindAsync(id);
            if (dataBaseOrder != null) 
            {
                _context.Orders.Remove(dataBaseOrder);
                await _context.SaveChangesAsync();

            }
        }

        public async Task<ICollection<Order>> GetOrderbyCustomerIdAsync(int customerId)
        {
            var databaseOrder = await _context.Orders.
                Where(o =>  o.CustomerId == customerId)
                .Include(o => o.Items)
                .ToListAsync();
            return databaseOrder;
        }

       

        public async Task<Order> GetOrderByIdAsync(int id)
        {
            return await _context.Orders
                .Include(order => order.Items)
                .Include(order => order.Customer)
                .FirstOrDefaultAsync(order => order.Id == id);
        }

        public async Task<ICollection<Order>> GetOrderByStatusAsync(Status status)
        {
            var databaseOrder = await _context.Orders.
                Where(o => o.Status == status)
                .Include(o => o.Items)
                .ToListAsync();
            return databaseOrder;
        }

        public async Task<List<Order>> GetOrdersAsync()
        {
            return await _context.Orders
                .Include(o => o.Items)
                .Include(o=> o.Customer)
                .ToListAsync();
        }


        public async Task<Order> UpdateOrderAsync(Order order)
        {
            var dataBaseOrder = await _context.Orders.FindAsync(order.Id);
            if (dataBaseOrder != null) 
            {
                dataBaseOrder.CustomerId = order.CustomerId;
                dataBaseOrder.Status = order.Status;
                dataBaseOrder.Customer = order.Customer;
            }
            await _context.SaveChangesAsync();
            return dataBaseOrder;
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
        
