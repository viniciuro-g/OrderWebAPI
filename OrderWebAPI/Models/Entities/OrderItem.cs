using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrderWebAPI.Models.Entities
{
    public class OrderItem
    {
        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        public string Description { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "A quantidade deve ser no mínimo 1.")]
        public int Quantity { get; set; }

        [Range(0.01, double.MaxValue, ErrorMessage = "O preço unitário deve ser maior que zero.")]
        public decimal UnitPrice { get; set; }

        public int OrderId { get; set; }

        public Order? Order { get; set; }

        [NotMapped]
        public decimal TotalPrice => UnitPrice * Quantity;

        public OrderItem()
        {
            Description = string.Empty;
        }
    }
}