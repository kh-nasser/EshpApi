using eshop_webapi.Contracts;
using eshop_webapi.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eshop_webapi.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        EshopApi_DBContext _dbContext;
        public CustomerRepository(EshopApi_DBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Customer> Add(Customer customer)
        {
            await _dbContext.Customers.AddAsync(customer);
            await _dbContext.SaveChangesAsync();
            return customer;
        }

        public async Task<int> CountCustomer()
        {
            return await _dbContext.Customers.CountAsync();
        }

        public async Task<Customer> Find(int id)
        {
            return await _dbContext.Customers.Include(c => c.Orders).SingleOrDefaultAsync(c => c.CustomerId == id);
        }

        public IEnumerable<Customer> GetAll()
        {
            return _dbContext.Customers.ToList();
        }

        public async Task<bool> IsExist(int id)
        {
            return await _dbContext.Customers.AnyAsync(c => c.CustomerId == id);
        }

        public async Task<Customer> Remove(int id)
        {
            var customer = await _dbContext.Customers.SingleAsync(c => c.CustomerId == id);
            _dbContext.Customers.Remove(customer);
            await _dbContext.SaveChangesAsync();
            return customer;
        }

        public async Task<Customer> Update(Customer customer)
        {
            _dbContext.Update(customer);
            await _dbContext.SaveChangesAsync();
            return customer;
        }
    }
}
