using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductApi.Data;
using ProductApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {

        private IApplicationDbContext _context;

        public ProductsController(IApplicationDbContext context)
        {
            _context = context;
        }

        //[HttpGet]
        //public async  Task<IActionResult> Get()
        //{
        //    var Product = await _context.Products.FirstOrDefaultAsync();

        //    return Ok(Product);
        //}

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var product = await _context.Products.Where(a => a.Id == id).FirstOrDefaultAsync();
            if (product == null) return NotFound();
            return Ok(product);
        }

        [HttpPost]
        public async Task<IActionResult> Post(Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChanges();
            return Ok(product);
        }

       

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var product = await _context.Products.Where(a => a.Id == id).FirstOrDefaultAsync();
            if (product == null) return NotFound();
            _context.Products.Remove(product);
            await _context.SaveChanges();
            return Ok(product.Id);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Product productData)
        {
            var product = _context.Products.Where(a => a.Id == id).FirstOrDefault();
            if (product == null) return NotFound();
            else
            {
                product.Name = productData.Name;
                product.Rate = productData.Rate;
                await _context.SaveChanges();
                return Ok(product.Id);
            }
        }



    }
}
