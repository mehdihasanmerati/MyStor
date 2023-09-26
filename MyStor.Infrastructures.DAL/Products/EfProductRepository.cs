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

        public void Add(Product product)
        {
           ctx?.Products?.Add(product);
           ctx?.SaveChanges();
        }

        public Product Find(int productId)
        {
            return ctx.Products.Find(productId);
        }

        public List<Product> GetProducts(string category, int pageSize = 4, int pageNumber = 1)
        {
            return ctx.Products.Where(c => string.IsNullOrWhiteSpace(category) || c.Category.CategoryName == category)
                               .Include(c => c.Category).Skip(pageSize * (pageNumber - 1)).Take(pageSize).ToList();
        }

        public int TotalCount(string category)
        {
            return ctx.Products.Count(c => string.IsNullOrWhiteSpace(category) || c.Category.CategoryName == category);
        }
    }
}
