using System.ComponentModel.DataAnnotations;

namespace BudgetWebAPI.DTOs
{
    public class CustomerUpdateDto
    {
        [Required(ErrorMessage ="ID do cliente é obrigatório")]
        public int Id { get; set; }
        [Required(ErrorMessage = "Nome do cliente é obrigatório")]
        [StringLength(200)]
        public string Name { get; set; }

        [Required(ErrorMessage = "E-mail do cliente é obrigatório")]
        [EmailAddress(ErrorMessage = "Formato de e-mail inválido")]
        [StringLength(200)]
        public string Email { get; set; }
        [StringLength(250)]
        public string? Address { get; set; }
    }
}
