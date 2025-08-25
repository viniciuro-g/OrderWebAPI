using BudgetWebAPI.Models.Enum;
using OrderWebAPI.Models.Entities;

namespace BudgetWebAPI.Services.Interfaces
{
    public interface IOrderService
    {
        public Task<ICollection<Order>> GetOrdersAsync();
        public Task<ICollection<Order>> GetOrdersByStatusAsync(Status status);
        public Task<Order> GetOrderByIdAsync(int id);
        public Task<ICollection<Order>> GetOrderByCostumerIdAsync(int orderId);
        public Task<Order> CreateOrderAsync(Order order);
        public Task<Order> UpdateOrderAsync(Order order);
        public Task<Order> DeleteOrderAsync(int id);

        // Order Items methods

        public Task<OrderItem> AddItemToOrderAsync(int orderId, OrderItem newItem); 
        public Task UpdateItemInOrderAsync(int orderId, int itemId, OrderItem updatedItem);
        public Task DeleteItemInOrderAsync(int orderId, int itemId);
    }
}
