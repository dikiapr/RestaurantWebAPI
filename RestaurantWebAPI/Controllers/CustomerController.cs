using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestaurantWebAPI.Models;
using RestaurantWebAPI.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerRepository customerRepository;

        public CustomerController(ICustomerRepository customerRepository)
        {
            this.customerRepository = customerRepository;
        }

        [HttpGet]
        public async Task<ActionResult> GetCustomers()
        {
            try
            {
                return Ok(await customerRepository.GetCustomer());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }

        [HttpPost]
        public async Task<ActionResult<Customer>> CreateCustomer(Customer customer)
        {
            try
            {
                if (customer == null)
                    return BadRequest();

                var createdCustomer = await customerRepository.AddCustomer(customer);

                return CreatedAtAction(nameof(GetCustomers),
                    new { id = createdCustomer.Id }, createdCustomer);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error creating new customer record");
            }
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<Customer>> UpdateCustomer(int id, Customer customer)
        {
            try
            {
                if (id != customer.Id)
                    return BadRequest("Customer ID mismatch");

                var customerToUpdate = await customerRepository.GetCustomerById(id);

                if (customerToUpdate == null)
                {
                    return NotFound($"Customer with Id = {id} not found");
                }

                return await customerRepository.UpdateCustomer(customer);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error updating customer record");
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeleteCustomer(int id)
        {
            try
            {
                var customerToDelete = await customerRepository.GetCustomerById(id);

                if (customerToDelete == null)
                {
                    return NotFound($"Customer with Id = {id} not found");
                }

                await customerRepository.DeleteCustomer(id);

                return Ok($"Customer with Id = {id} deleted");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error deleting customer record");
            }
        }
    }
}
