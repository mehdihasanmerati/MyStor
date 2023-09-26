using Microsoft.AspNetCore.Mvc;
using MyStor.Core.Contracts.Categories;
using MyStor.Core.Contracts.Products;
using MyStor.Core.Domain.Products;
using MyStor.EndPoints.AdminPanel.Models.Products;


namespace MyStor.EndPoints.AdminPanel.Controllers
{
    public class ProductController : Controller
    {
        private readonly CategoryRepository categoryRepository;
        private  ProductRepository productRepository;

        public ProductController(CategoryRepository categoryRepository, ProductRepository productRepository)
        {
            this.categoryRepository = categoryRepository;
            this.productRepository = productRepository;
        }
        public IActionResult Index()
        {
            var products = productRepository.GetProducts("", 100, 1);
            return View(products);
        }
        public IActionResult Add()
        {
            AddProductViewModel model = new AddProductViewModel
            {
                CategoyForDisplay = categoryRepository.GetAll()
            };
            return View(model);
        }
        [HttpPost]
        public IActionResult Add(AddProductViewModel model)
        {
            if (ModelState.IsValid)
            {
                Product product = new Product
                {
                    CategoryId = model.CatagoryId,
                    Description = model.Description,
                    Name = model.Name,
                    Price = model.Price,
                };
                if (model?.Image?.Length > 0)
                {
                    using (var sm = new MemoryStream())
                    {
                        model.Image.CopyTo(sm);
                        var fileBytes = sm.ToArray();
                        product.Image = "data:image/jpeg;base64," + Convert.ToBase64String(fileBytes);
                    } ;
                }
                productRepository.Add(product);
                return RedirectToAction("Index");
            }
            categoryRepository.GetAll();
            return View(model);
        }
    }
    
}
