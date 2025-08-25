using BudgetWebAPI.Models.Enum;
using BudgetWebAPI.Repositories.Interfaces;
using BudgetWebAPI.Services.Interfaces;
using OrderWebAPI.Models.Entities;
using BudgetWebAPI.Services.Exceptions;

namespace BudgetWebAPI.Services.Implementation
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly ICustomerRepository _customerRepository;

        public OrderService(IOrderRepository orderRepository,ICustomerRepository customerRepository)
        {
            _orderRepository = orderRepository;
            _customerRepository = customerRepository;
        }


        public async Task<Order> CreateOrderAsync(Order order)
        {
            var validationErrors = new List<string>();

            var customer = await _customerRepository.GetByIdAsync(order.CustomerId);
            if (customer == null) 
            {
                validationErrors.Add("O Cliente inserido é inválido ou inexistente");
            }

            if (order.Items == null) 
            {
                validationErrors.Add("O orçamento deve conter no mínimo um item.");
            }
            else 
            {
                foreach (var item in order.Items) 
                {
                    if (item.Quantity <= 0) 
                    {
                        validationErrors.Add($"A quantidade do item '{item.Description}' deve ser maior que 0");
                    }
                }
            }

            if (validationErrors.Any())
            {
                throw new ValidationException(validationErrors);
            }
            order.Status = Status.Draft;
            order.CreatedAt = DateTime.Now;
            var newOrder = await _orderRepository.CreateOrderAsync(order);
            return newOrder;

        }
        

        public async Task<Order> DeleteOrderAsync(int id)
        {
            var order = await _orderRepository.GetOrderByIdAsync(id);
            if (order == null)
            {
                throw new NotFoundException("Orçamento", id);
            }
            await _orderRepository.DeleteOrderAsync(order.Id);
            return order;
        }

        public async Task<ICollection<Order>> GetOrderByCostumerIdAsync(int costumerId)
        {
            var costumer = await _customerRepository.GetByIdAsync(costumerId);
            if (costumer == null) 
            {
                throw new NotFoundException("Cliente", costumerId);
            }
            return await _orderRepository.GetOrderbyCustomerIdAsync(costumer.Id);
        }

        public async Task<Order> GetOrderByIdAsync(int id)
        {
            var order = await _orderRepository.GetOrderByIdAsync(id);
            if (order == null) 
            {
                throw new NotFoundException("Orçamento", id);
            }
            return order;
        }

        public async Task<ICollection<Order>> GetOrdersAsync()
        {
            var orders = await _orderRepository.GetOrdersAsync();
            if (orders == null) 
            {
                throw new NotFoundException("Nenhum orçamento encontrado");
            }
            return orders;
        }

        public async Task<ICollection<Order>> GetOrdersByStatusAsync(Status status)
        {
            var orders = await _orderRepository.GetOrderByStatusAsync(status);
            if (orders == null)
            {
                throw new NotFoundException("Nenhum orçamento encontrado");
            }
            return orders;
        }

        

        public async Task<Order> UpdateOrderAsync(Order order)
        {
            var updatedOrder = await _orderRepository.UpdateOrderAsync(order);
            return updatedOrder;
        }


        // OrderItem methods
        public async Task<OrderItem> AddItemToOrderAsync(int orderId, OrderItem newItem)
        {
            var order = await _orderRepository.GetOrderByIdAsync(orderId);
            if (order == null)
            {
                throw new NotFoundException("Orçamento", orderId);
            }
            order.Items.Add(newItem);
            await _orderRepository.SaveChangesAsync();
            return newItem;
        }

        public async Task UpdateItemInOrderAsync(int orderId, int itemId, OrderItem updatedItem)
        {
            var order = await _orderRepository.GetOrderByIdAsync(orderId);
            if (order == null) 
            {
                throw new NotFoundException("Orçamento", orderId);
            }

            var databaseItem = order.Items.FirstOrDefault(i => i.Id == itemId);
            if (databaseItem == null) 
            {
                throw new NotFoundException("Item do Orçamento", itemId);
            }
            databaseItem.Description = updatedItem.Description;
            databaseItem.Quantity = updatedItem.Quantity;
            databaseItem.UnitPrice = updatedItem.UnitPrice;

            await _orderRepository.SaveChangesAsync(); 
        }

        public async Task DeleteItemInOrderAsync(int orderId, int itemId)
        {
            var order = await _orderRepository.GetOrderByIdAsync(orderId);
            if (order == null)
            {
                throw new NotFoundException("Orçamento", orderId);
            }

            var databaseItem = order.Items.FirstOrDefault(i =>i.Id == itemId);
            if (databaseItem == null) 
            {
                throw new NotFoundException("Item do Orçamento", itemId);
            }

            order.Items.Remove(databaseItem);
            await _orderRepository.SaveChangesAsync();
            
        }


    }
}
