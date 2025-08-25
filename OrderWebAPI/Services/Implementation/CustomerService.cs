using BudgetWebAPI.Repositories.Interfaces;
using BudgetWebAPI.Services.Exceptions;
using BudgetWebAPI.Services.Interfaces;
using OrderWebAPI.Models.Entities;

namespace BudgetWebAPI.Services.Implementation
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<Customer> CreateCustomerAsync(Customer customer)
        {
            var newCustomer = await _customerRepository.CreateCustomerAsync(customer);
            return newCustomer;
        }

        public async Task<Customer> DeleteCustomerAsync(int id)
        {
            var customer = await _customerRepository.DeleteCustomerAsync(id);
            if (customer == null)
            {
                throw new NotFoundException("Cliente", id);
            }
            return customer;
        }

        public async Task<Customer> GetCustomerByIdAsync(int id)
        {
            var customer = await _customerRepository.GetByIdAsync(id);
            if (customer == null) 
            {
                throw new NotFoundException("Cliente", id);
            }
            return customer;
        }

        public async Task<ICollection<Customer>> GetCustomersAsync()
        {
            return await _customerRepository.GetCustomersAsync();
        }

        public async Task<Customer> UpdateCustomerAsync(Customer customer)
        {
            var updatedCustomer = await _customerRepository.UpdateCustomerAsync(customer);
            return updatedCustomer;
        }
    }
}
