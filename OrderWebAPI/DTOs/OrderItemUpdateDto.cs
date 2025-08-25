using System.ComponentModel.DataAnnotations;

namespace BudgetWebAPI.DTOs
{
    public class OrderItemUpdateDto
    {
        public int Id { get; set; }

        [Required]
        public string Description { get; set; }

        [Range(1, 999)]
        public int Quantity { get; set; }

        [Range(0.01, double.MaxValue)]
        public decimal UnitPrice { get; set; }
    }
}
