using MyStor.Core.Domain.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStor.Core.Contracts.Products
{
    public interface ProductRepository
    {
        int TotalCount(string category);
        List<Product> GetProducts(string category, int pageSize = 4, int pageNumber = 1);
    }
}
