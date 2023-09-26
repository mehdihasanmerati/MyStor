using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyStor.Core.Contracts.Orders;

namespace MyStor.EndPoints.AdminPanel.Controllers
{
    [Authorize]
    public class OrderController : Controller
    {
        private readonly OrderRepository repository;

        public OrderController(OrderRepository repository)
        {
            this.repository = repository;
        }
        public IActionResult NewOrders()
        {
            var result = repository.Search(false);
            return View(result);
        }
        public IActionResult ViewDetail(int id)
        {
            var order = repository.Find(id);
            if (order == null)
            {
                return NotFound();
            }
            return View(order);
        }
        [HttpPost]
        public IActionResult Ship(int id)
        {
            var order = repository.Find(id);
            if (order == null)
            {
                return NotFound();
            }
            return RedirectToAction(nameof(NewOrders));
        }
    }
}
