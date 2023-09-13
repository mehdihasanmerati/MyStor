using Microsoft.AspNetCore.Mvc;
using MyStor.Core.Contracts.Products;

namespace MyStor.EndPoints.WebUI.Controllers
{
    public class ProductController : Controller
    {
        private readonly ProductRepository productRepository;

        public ProductController(ProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }
        public IActionResult List()
        {
            var product = productRepository.GetProducts();
            return View(product);
        }
    }
}
