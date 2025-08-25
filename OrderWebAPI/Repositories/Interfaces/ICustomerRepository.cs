using OrderWebAPI.Models.Entities;

namespace BudgetWebAPI.Repositories.Interfaces
{
    public interface ICustomerRepository
    {
        public Task<List<Customer>> GetCustomersAsync();
        public Task<Customer> GetByIdAsync(int id);
        public Task<Customer> CreateCustomerAsync(Customer customer);
        public Task<Customer> UpdateCustomerAsync(Customer customer);
        public Task<Customer> DeleteCustomerAsync(int id);
    }
}
