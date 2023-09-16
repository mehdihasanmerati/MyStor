using MyStor.Core.Domain.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStor.Core.Contracts.Categories
{
    public interface CategoryRepository
    {
        List<Category> GetAll();
    }
}
