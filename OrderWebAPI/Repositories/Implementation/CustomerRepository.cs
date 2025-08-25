using BudgetWebAPI.Data;
using BudgetWebAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using OrderWebAPI.Models.Entities;

namespace BudgetWebAPI.Repositories.Implementation
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly AppDbContext _context;

        public CustomerRepository(AppDbContext context)
        {
            _context = context;
        }



        public async Task<Customer> CreateCustomerAsync(Customer customer)
        {
            await _context.AddAsync(customer);
            await _context.SaveChangesAsync();

            return customer;
        }

        public async Task<Customer> DeleteCustomerAsync(int id)
        {
            var customer = await GetByIdAsync(id);
            if (customer != null) 
            {
                _context.Remove(customer);
                await _context.SaveChangesAsync();
            }
            return customer;
        }

        public async Task<Customer> GetByIdAsync(int id)
        {
            return await _context.Customers.FindAsync(id);
        }

        public async Task<List<Customer>> GetCustomersAsync()
        {
            return await _context.Customers.ToListAsync();
        }

        public async Task<Customer> UpdateCustomerAsync(Customer customer)
        {
            var DatabaseCustomer = await _context.Customers.FindAsync(customer.Id);
            if (DatabaseCustomer != null) 
            {
                DatabaseCustomer.Address = customer.Address;
                DatabaseCustomer.Name = customer.Name;
                DatabaseCustomer.Email = customer.Email;
            }
            await _context.SaveChangesAsync();
            return DatabaseCustomer;
        }
    }
}
