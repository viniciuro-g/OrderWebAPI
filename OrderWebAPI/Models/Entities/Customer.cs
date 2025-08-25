using System.ComponentModel.DataAnnotations;

namespace OrderWebAPI.Models.Entities
{
    public class Customer
    {
        public int Id { get; set; }

        [EmailAddress]
        [StringLength(100)]
        public string Email { get; set; } = string.Empty;
        [StringLength(200)]
        public string Name { get; set; } = string.Empty;

        [StringLength(250)]
        public string? Address { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}
