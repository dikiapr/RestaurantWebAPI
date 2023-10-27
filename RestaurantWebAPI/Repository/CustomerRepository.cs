using Microsoft.EntityFrameworkCore;
using RestaurantWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantWebAPI.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly AppDbContext appDbContext;

        public CustomerRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public async Task<Customer> AddCustomer(Customer customer)
        {
            var result = await appDbContext.Customers.AddAsync(customer);
            await appDbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task DeleteCustomer(int customerId)
        {
            var result = await appDbContext.Customers
                .FirstOrDefaultAsync(e => e.Id == customerId);

            if (result != null)
            {
                appDbContext.Customers.Remove(result);
                await appDbContext.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Customer>> GetCustomer()
        {
            return await appDbContext.Customers.ToListAsync();
        }

        public async Task<Customer> GetCustomerById(int customerId)
        {
            return await appDbContext.Customers
                //.Include(e => e.Department)
                .FirstOrDefaultAsync(e => e.Id == customerId);
        }

        public async Task<Customer> UpdateCustomer(Customer customer)
        {
            var result = await appDbContext.Customers
               .FirstOrDefaultAsync(e => e.Id == customer.Id);

            if (result != null)
            {
                result.Nama = customer.Nama;
                result.Alamat= customer.Alamat;

                await appDbContext.SaveChangesAsync();

                return result;
            }

            return null;
        }
    }
}
