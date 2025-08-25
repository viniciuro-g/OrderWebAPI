using System.ComponentModel.DataAnnotations;

namespace BudgetWebAPI.DTOs
{
    public class OrderItemCreateDto
    {
        [Required(ErrorMessage = "A descrição do item é obrigatória.")]
        [StringLength(250)]
        [MinLength(1)]
        public string Description { get; set; }

        [Required(ErrorMessage = "A quantidade é obrigatória.")]
        [Range(1, 999, ErrorMessage = "A quantidade deve ser maior que zero.")]
        public int Quantity { get; set; }

        [Required(ErrorMessage = "O preço unitário é obrigatório.")]
        [Range(0.01, 1000000.00, ErrorMessage = "O preço deve ser maior que zero.")]
        public decimal UnitPrice { get; set; }
    }
}
