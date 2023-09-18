using Microsoft.AspNetCore.Mvc;
using MyStor.Core.Contracts.Products;
using MyStor.Core.Domain.Carts;
using MyStor.Core.Domain.Products;
using MyStor.EndPoints.WebUI.Infrastructures;
using MyStor.EndPoints.WebUI.Models.Carts;

namespace MyStor.EndPoints.WebUI.Controllers
{
    public class CartController : Controller
    {
        private ProductRepository repository;
        private Cart _cart;

        public CartController(ProductRepository repository, Cart cart)
        {
            this.repository = repository;
            _cart = cart;
        }

        public ViewResult Index(string returnUrl)
        {
            return View(new CartIndexViewModel
            {
                Cart = _cart,
                ReturnUrl = returnUrl,
            });
        }

        [HttpPost]
        public RedirectToActionResult AddToCart(int productId, string returnUrl)
        {
            Product product = repository.Find(productId);
            if (product != null)
            {
                _cart.AddItem(product, 1);
            }
            return RedirectToAction("Index", new {returnUrl});
        }

        public RedirectToActionResult RemoveFromCart(int productId, string returnUrl)
        {
            Product product = repository.Find(productId);
            if (product != null)
            {
                _cart.RmoveLine(product);
            }
            return RedirectToAction("Index", new { returnUrl });
        }
    }
}
