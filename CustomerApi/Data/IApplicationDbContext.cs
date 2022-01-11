using CustomerApi.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerApi.Data
{
    public interface IApplicationDbContext
    {


        public DbSet<Customer> Customers { get; set; }


        public DbSet<ProductDelivered> ProductDelivered { get; set; }

        Task<int> SaveChanges();

    }
}
