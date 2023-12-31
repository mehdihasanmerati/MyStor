﻿using MyStor.Core.Domain.Carts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStor.Core.Domain.Orders
{
    public class OrderHeader
    {
        public int OrderID { get; set;}
        public string Name { get; set; }
        public string Line1 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PaymentId { get; set; }
        public DateTime? PaymentDate { get; set; }
        public bool Shipped { get; set; }
        public bool HasPayment => PaymentDate.HasValue;
        public decimal TotalPrice { get; set; }
    }

    public class Order
    {
        public int OrderId { get; set; }
        public ICollection<CartLine>? lines { get; set; }

        [Required(ErrorMessage = "Please enter a name")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Please enter your first address line")]
        public string? Line1 { get; set; }
        public string? Line2 { get; set; }
        public string? Line3 { get; set; }

        [Required(ErrorMessage = "Please enter a City")]
        public string? City { get; set; }

        [Required(ErrorMessage = "Please enter a state name")]
        public string? State { get; set; }
        public string? Zip { get; set; }

        [Required(ErrorMessage = "Please enter a country name")]
        public string? Country { get; set; }
        public bool GiftWrap { get; set; }

        public string? PaymentId { get; set; }
        public DateTime? PaymentDate { get; set; }
        public bool Shipped { get; set; }
    }
}
