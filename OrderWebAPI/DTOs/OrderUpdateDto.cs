using System.ComponentModel.DataAnnotations;

namespace BudgetWebAPI.DTOs
{
    public class OrderUpdateDto
    {
        [Required(ErrorMessage = "O ID do orçamento é obrigatório.")]
        public int Id { get; set; }

        [Required(ErrorMessage = "O Status é obrigatório.")]
        public string Status { get; set; }

        [StringLength(500)]
        public string? Description { get; set; }
    }
}
