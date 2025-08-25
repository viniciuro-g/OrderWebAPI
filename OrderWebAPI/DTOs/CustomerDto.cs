using System.ComponentModel.DataAnnotations;

namespace BudgetWebAPI.DTOs
{
    public class CustomerDto
    {

        public int Id { get; set; }
        public string Email { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string? Address { get; set; }
    }
}
