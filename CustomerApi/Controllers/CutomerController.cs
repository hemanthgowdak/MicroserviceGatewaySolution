using CustomerApi.Data;
using CustomerApi.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CutomerController : ControllerBase
    {

        private IApplicationDbContext _context;

        public CutomerController(IApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById(int Id)
        {

            var Result = await _context.Customers.Where(a => a.Id == Id).FirstOrDefaultAsync();

            return Ok(Result);

        }

        [HttpPost]
        public async Task<IActionResult> PostCustomer(Customer customer)
        {
            _context.Customers.Add(customer);
            await _context.SaveChanges();

            return Ok(customer);


        }

        [HttpPut("{Id}")]
        public async Task<IActionResult> UpdateCustomer(int Id,Customer customerData)
        {

            var customer = _context.Customers.Where(a => a.Id == Id).FirstOrDefault();
            if (customer !=null)
            {

                customer.City = customerData.City;
                customer.Name = customerData.Name;
                customer.Contact = customerData.Contact;
                customer.Email = customerData.Email;
                await _context.SaveChanges();
                return Ok(customer.Id);

            }
            {
                return NotFound();
            }

        }


        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete(int Id)
        {
            var customer = await _context.Customers.Where(a => a.Id == Id).FirstOrDefaultAsync();
            if (customer == null) return NotFound();
            _context.Customers.Remove(customer);
            await _context.SaveChanges();
            return Ok(customer.Id);
        }




    }
}
