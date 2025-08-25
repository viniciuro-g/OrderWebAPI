using OrderWebAPI.Models.Entities;
using System.ComponentModel.DataAnnotations;

namespace BudgetWebAPI.DTOs
{
    public class OrderItemDto
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalPrice { get; set; }

    }
}
