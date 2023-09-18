using MyStor.Core.Domain.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStor.Core.Domain.Carts
{
    public class CartLine
    {
        public int CartLineId { get; set; }
        public Product? Product { get; set; }
        public int Quantity { get; set; }
    }
}
