using Microsoft.AspNetCore.Mvc;
using MyStor.Core.Contracts.Orders;
using MyStor.Core.Domain.Carts;
using MyStor.Core.Domain.Orders;

namespace MyStor.EndPoints.WebUI.Controllers
{
    public class OrderController : Controller
    {
        private OrderRepository repository;
        private Cart cart;

        public OrderController(OrderRepository repoService, Cart cartService)
        {
            repository = repoService;
            cart = cartService;
        }
        public ViewResult Checkout()
        {
            return View(new Order());
        }

        [HttpPost]
        public IActionResult Checkout(Order order)
        {
            if (cart.Lines.Count() == 0)
            {
                ModelState.AddModelError("", "Sorry, your cart is empty!");
            }
            if (ModelState.IsValid)
            {
                order.lines = cart.Lines.ToArray();
                repository.SaveOrder(order);
                return RedirectToAction(nameof(Completed), new {Id = order.OrderId});
            }
            else
            {
                return View(order);
            }
        }

        public IActionResult Completed(int id)
        {
            var order = repository.Find(id);
            if (order == null)
            {
                return NotFound();
            }
            return View(order);
        }

    }
}
