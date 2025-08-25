using BudgetWebAPI.Models.Enum;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace OrderWebAPI.Models.Entities
{
    public class Order
    {
        public int Id { get; set; }


        public Status Status { get; set; }

        public DateTime CreatedAt { get; set; }

        [StringLength(500)]
        public string? Description { get; set; }

        public int CustomerId { get; set; }

        public Customer? Customer { get; set; }

        public ICollection<OrderItem> Items { get;  set; }

        [NotMapped]
        public decimal TotalValue => Items?.Sum(i => i.TotalPrice) ?? 0;

        [NotMapped]
        public int ItemsQuantity => Items?.Count ?? 0;

        public Order()
        {
            Items = new List<OrderItem>();
            Status = Status.Draft;
            CreatedAt = DateTime.UtcNow;
        }
    }
}