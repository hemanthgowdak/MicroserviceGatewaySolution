using CustomerApi.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerApi.Data
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {
           
        }

        public DbSet<Customer> Customers { get; set ; }
        public DbSet<ProductDelivered> ProductDelivered { get ; set ; }

        public async Task<int> SaveChanges()
        {
           return await base.SaveChangesAsync();
        }
    }
}
