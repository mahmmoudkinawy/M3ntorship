using Laptop.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Laptop.Data
{
    public class LaptopObjectsDbContext : DbContext
    {
        public LaptopObjectsDbContext(DbContextOptions<LaptopObjectsDbContext> options) :base(options)
        {

        }
        public DbSet<LaptopObjects> laptops { get; set; }
    }
}
