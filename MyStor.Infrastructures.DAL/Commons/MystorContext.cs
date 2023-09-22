using Microsoft.EntityFrameworkCore;
using MyStor.Core.Domain.Categories;
using MyStor.Core.Domain.Orders;
using MyStor.Core.Domain.Products;
using MyStor.Infrastructures.DAL.Categories;
using MyStor.Infrastructures.DAL.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStor.Infrastructures.DAL.Commons
{
    public class MystorContext: DbContext
    {
        public MystorContext(DbContextOptions<MystorContext> options) : base(options) { }
     
        public DbSet<Product>? Products { get; set; }
        public DbSet<Category>? Categories { get; set; }
        public DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            base.OnModelCreating(modelBuilder);
        }

    }
}
