using Microsoft.EntityFrameworkCore;
using ProductApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductApi.Data
{
     public interface IApplicationDbContext
    {


        public DbSet<Product> Products { get; set; }
        Task<int> SaveChanges();


    }
}
