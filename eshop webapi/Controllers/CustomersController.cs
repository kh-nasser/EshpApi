using eshop_webapi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace eshop_webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private EshopApi_DBContext _context;

        public CustomersController(EshopApi_DBContext context)
        {
            _context = context;
        }


        [HttpGet]
        public IActionResult GetCustomer()
        {
            var result = new ObjectResult(_context.Customers)
            {
                StatusCode = (int)HttpStatusCode.OK
            };
            Request.HttpContext.Response.Headers.Add("X-Count", _context.Customers.Count().ToString());
            Request.HttpContext.Response.Headers.Add("X-Name", "Name");

            return result;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCustomer([FromRoute] int id)
        {
            if (CustomerExists(id))
            {
                var customer = await _context.Customers.SingleOrDefaultAsync(c => c.CustomerId == id);
                return Ok(customer);
            }
            else { 
                return NotFound();  
            }
        }

        private bool CustomerExists(int id)
        {
            return _context.Customers.Any(c => c.CustomerId == id);
        }

        [HttpPost]
        public async Task<IActionResult> PostCustomer([FromBody] Customer customer)
        {
            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetCustomer", new { id = customer.CustomerId }, customer);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutCustomer([FromRoute] int id, [FromBody] Customer customer)
        {
            _context.Entry(customer).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return Ok(customer);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer([FromRoute] int id)
        {
            var customer = await _context.FindAsync<Customer>(id);
            _context.Remove(customer);
            await _context.SaveChangesAsync();
            return Ok();
        }

    }
}
