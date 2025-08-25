using BudgetWebAPI.Models.Enum;
using OrderWebAPI.Models.Entities;
using System.ComponentModel.DataAnnotations;

namespace BudgetWebAPI.DTOs
{
    public class OrderDto
    {
        public int Id { get; set; }
        public string? Description { get; set; }
        public ICollection<OrderItemDto> Items { get; set; }
        public decimal TotalValue { get; set; }
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public DateTime CreatedAt { get; set; }
        public Status Status { get; set; }

    }
}
