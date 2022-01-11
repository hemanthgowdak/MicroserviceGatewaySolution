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
    public class ProductDeliveryController : ControllerBase
    {

        private IApplicationDbContext _context;


        public ProductDeliveryController(IApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> PostCustomer(ProductDelivered productDelivered)
        {
            _context.ProductDelivered.Add(productDelivered);
            await _context.SaveChanges();

            return Ok(productDelivered);


        }


        [HttpGet]
        public async Task<IActionResult> GetAllProductsOnId(int Id)
        {
            var customer = await _context.Customers.Where(a => a.Id == Id).FirstOrDefaultAsync();

            var ProductDeliverd = await _context.ProductDelivered.Where(b => b.Id == Id).FirstOrDefaultAsync();

            var result =await (from c in _context.Customers
                          join pd in _context.ProductDelivered
                          on c.Id equals pd.CustomerId
                          where pd.CustomerId == Id
                          select new { c.Id,c.Name, c.City }
                           ).FirstOrDefaultAsync();

            result.Equals("success");


            return Ok(result);

        }

    }
}
