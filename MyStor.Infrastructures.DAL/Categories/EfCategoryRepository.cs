using MyStor.Core.Contracts.Categories;
using MyStor.Core.Domain.Categories;
using MyStor.Infrastructures.DAL.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStor.Infrastructures.DAL.Categories
{
    public class EfCategoryRepository : CategoryRepository
    {
        private readonly MystorContext ctx;

        public EfCategoryRepository(MystorContext ctx)
        {
            this.ctx = ctx;
        }
        public List<Category> GetAll()
        {
            return ctx.Categories.ToList();
        }
    }
}
