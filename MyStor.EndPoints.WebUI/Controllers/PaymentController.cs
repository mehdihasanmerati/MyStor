using Microsoft.AspNetCore.Mvc;
using MyStor.Core.Contracts.Orders;
using MyStor.Core.Contracts.Payments;
using MyStor.Core.Domain.Payments;

namespace MyStor.EndPoints.WebUI.Controllers
{
    public class PaymentController : Controller
    {
        private readonly OrderRepository orderRepository;
        private readonly PaymentService payment;
        private readonly IConfiguration configuration;

        public PaymentController(OrderRepository repository, PaymentService payment, IConfiguration configuration)
        {
            this.orderRepository = repository;
            this.payment = payment;
            this.configuration = configuration;
        }

        [HttpPost]
        public IActionResult RequestPayment(int orderId)
        {
            var order = orderRepository.Find(orderId);
            var result = payment.RequestPayment(order.lines.Sum(c => c.Product.Price).ToString(), "09122345677", order.OrderId.ToString(), $"Description {order.Name}", "6104256545891236");
            if(result.IsCorrect)
            {
                orderRepository.SetTransactionId(orderId, result.Token);
                return Redirect($"{configuration["PayIr:PaymentUrl"]}{result.Token}");
            }
            return View(result);
        }

        public IActionResult Verify(RequestPaymentRsult result)
        {
            if (result.IsCorrect)
            {
                var verifyResult = payment.VerifyPayment(result.Token.ToString());
                if (verifyResult.IsCorrect)
                {
                    orderRepository.SetPaymentDone(verifyResult.factorNumber);
                    return View("PaymentComplete", verifyResult);
                }
            }
            return View("PaymentError", result);
        }
    }
}
