using Microsoft.AspNetCore.Mvc;
using MyStor.Core.Contracts.Products;
using MyStor.EndPoints.WebUI.Models.Products;

namespace MyStor.EndPoints.WebUI.Controllers
{
    public class ProductController : Controller
    {
        private readonly ProductRepository productRepository;

        public ProductController(ProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }
        public IActionResult List(string category ,int pageNumber = 1)
        {
            var model = new ProductListViewModel
            {
                Products = productRepository.GetProducts(category,2,pageNumber),
                PagingInfo = new Models.Common.PagingInfo
                {
                    CurrentPage = pageNumber,
                    ItemsPerPage = 2,
                    TotalItems = productRepository.TotalCount(category)
                },
                CurrentCategory = category
            };
            return View(model);
        }
    }
}
