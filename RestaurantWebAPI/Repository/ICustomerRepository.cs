using RestaurantWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantWebAPI.Repository
{
     public interface ICustomerRepository
    {
        Task<IEnumerable<Customer>> GetCustomer();

        Task<Customer> GetCustomerById(int customerId);
        Task<Customer> AddCustomer(Customer customer);
        Task<Customer> UpdateCustomer(Customer customer);
        Task DeleteCustomer(int customerId);
    }
}
