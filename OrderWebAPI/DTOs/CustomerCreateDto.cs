using System.ComponentModel.DataAnnotations;

namespace BudgetWebAPI.DTOs
{
    public class CustomerCreateDto
    {
        [Required(ErrorMessage ="Nome do cliente é obrigatório")]
        [MinLength(3)]
        [MaxLength(200)]
        public string Name { get; set; }

        [Required(ErrorMessage ="E-mail do cliente é obrigatório")]
        [EmailAddress(ErrorMessage ="Formato de e-mail inválido")]
        [StringLength(200)]
        public string Email { get; set; }
        [StringLength(250)]
        public string? Address { get; set; }
    }
}
