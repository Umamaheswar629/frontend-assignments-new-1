using CustomerApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace CustomerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        //In-memory data store (static-list)
        private static List<Customer> customers = new List<Customer>
        {
            new Customer{CustomerId=101,CustomerName="ram",Balance=50588.78m},
            new Customer{CustomerId=102,CustomerName ="raju",Balance=7887887.99m }

        };
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(customers);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var customer = customers.FirstOrDefault(c => c.CustomerId == id);
            if (customer == null)
            {
                return NotFound("ID not found");
            }
            return Ok(customer);
        }
        [HttpPost]
        public IActionResult Create(Customer customer)
        {
            customer.CustomerId = customers.Max(p => p.CustomerId) + 1;
            customers.Add(customer);
            return CreatedAtAction(nameof(GetById),
            new { id = customer.CustomerId }, customer);
        }
        [HttpPut("{id}")]
        public IActionResult Update(int id,Customer UpdatedCustomer)
        {
            var c = customers.FirstOrDefault(p => p.CustomerId == id);
            if (c == null) return NotFound("Customer ledu bhai");
            c.CustomerName = UpdatedCustomer.CustomerName;
            c.Balance = UpdatedCustomer.Balance;
            return NoContent();

        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var c = customers.FirstOrDefault(p => p.CustomerId == id);
            if (c == null) return NotFound("Customer ledu bhai");
            customers.Remove(c);
            return NoContent();
        }
    }
}
