using MyStor.Core.Domain.Products;
using MyStor.EndPoints.WebUI.Models.Common;

namespace MyStor.EndPoints.WebUI.Models.Products
{
    public class ProductListViewModel
    {
        public List<Product> Products { get; set; }
        public PagingInfo PagingInfo { get; set; }
        public string CurrentCategory { get; set; }
    }
}
