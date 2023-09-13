using Microsoft.EntityFrameworkCore;
using MyStor.Core.Contracts.Products;
using MyStor.Core.Domain.Products;
using MyStor.Infrastructures.DAL.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStor.Infrastructures.DAL.Products
{
    public class EfProductRepository : ProductRepository
    {
        private readonly MystorContext ctx;

        public EfProductRepository(MystorContext ctx)
        {
            this.ctx = ctx;
        }
        public List<Product> GetProducts()
        {
#pragma warning disable CS8604 // Possible null reference argument.
            return ctx.Products.Include(c => c.Category).ToList();
#pragma warning restore CS8604 // Possible null reference argument.
        }
    }
}
