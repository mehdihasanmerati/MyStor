using MyStor.Core.Domain.Carts;

namespace MyStor.EndPoints.WebUI.Models.Carts
{
    public class CartIndexViewModel
    {
        public Cart Cart { get; set; }
        public string ReturnUrl { get; set;}
    }
}
