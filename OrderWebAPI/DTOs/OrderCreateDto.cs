using System.ComponentModel.DataAnnotations;

namespace BudgetWebAPI.DTOs
{
    public class OrderCreateDto
    {
        [Required(ErrorMessage ="É obrigatório informar cliente")]
        public int CustomerId { get; set; }
        [StringLength(500)]
        public string? Description { get; set; }

        [Required]
        public List<OrderItemCreateDto> Items { get; set; }
    }
}
