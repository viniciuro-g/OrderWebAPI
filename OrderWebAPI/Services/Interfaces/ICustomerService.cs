using OrderWebAPI.Models.Entities;

namespace BudgetWebAPI.Services.Interfaces
{
    public interface ICustomerService
    {
        public Task<ICollection<Customer>> GetCustomersAsync();
        public Task<Customer> GetCustomerByIdAsync(int id);
        public Task<Customer> CreateCustomerAsync(Customer customer);
        public Task<Customer> UpdateCustomerAsync(Customer customer);
        public Task<Customer> DeleteCustomerAsync(int id);
    }
}
