using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECommerceApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceApp.Controllers
{
    [Produces("application/json")]
    [Route("api/Customer")]
    public class CustomerController : Controller
    {
        ECommerceContext _context;
        public CustomerController(ECommerceContext context)
        {
            _context = context;
        }

        List<Customer> customerList = new List<Customer>();
        // GET: api/Customer
        [HttpGet]
        public IEnumerable<Customer> Get()
        {
            return _context.Customers.ToList();
        }

        // GET: api/Customer/5
        [HttpGet("{id}", Name = "Get")]
        public Customer Get(int id)
        {
            return _context.Customers.FirstOrDefault(p => p.CustomerId == id);
        }
        
        // POST: api/Customer
        [HttpPost]
        public void Post([FromBody]Customer customer)
        {
            _context.Customers.Add(customer);
            _context.SaveChanges();
        }

        // PUT: api/Customer/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]Customer newCustomer)
        {
            Customer oldCustomer = _context.Customers.FirstOrDefault(p => p.CustomerId == id);
            oldCustomer.Name= newCustomer.Name;
            oldCustomer.Address = newCustomer.Address;
            oldCustomer.EMail = newCustomer.EMail;
            oldCustomer.PhoneNumber= newCustomer.PhoneNumber;
            _context.Customers.Update(oldCustomer);
            _context.SaveChanges();
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            Customer customer = _context.Customers.FirstOrDefault(p => p.CustomerId == id);
            _context.Customers.Remove(customer);
            _context.SaveChanges();
        }
    }
}
