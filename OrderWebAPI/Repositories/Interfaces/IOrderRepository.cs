using BudgetWebAPI.Models.Enum;
using OrderWebAPI.Models.Entities;

namespace BudgetWebAPI.Repositories.Interfaces
{
    public interface IOrderRepository
    {  
        public Task<List<Order>> GetOrdersAsync();
        public Task<Order> GetOrderByIdAsync(int id);
        public Task<ICollection<Order>> GetOrderbyCustomerIdAsync(int customerId);
        public Task<ICollection<Order>> GetOrderByStatusAsync(Status status);
        public Task<Order> CreateOrderAsync(Order order);
        public Task<Order> UpdateOrderAsync(Order order);
        public Task DeleteOrderAsync(int id);
        public Task<int> SaveChangesAsync();
    }
}
