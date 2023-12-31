﻿using Microsoft.EntityFrameworkCore;
using MyStor.Core.Contracts.Orders;
using MyStor.Core.Domain.Orders;
using MyStor.Infrastructures.DAL.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStor.Infrastructures.DAL.Orders
{
    public class EfOrderRepository : OrderRepository
    {
        private readonly MystorContext ctx;

        public EfOrderRepository(MystorContext ctx)
        {
            this.ctx = ctx;
        }

        public Order Find(int id)
        {
            return ctx.Orders.Include(c => c.lines).ThenInclude(d => d.Product).FirstOrDefault(c => c.OrderId == id);  
        }

        public void SaveOrder(Order order)
        {
            ctx.AttachRange(order.lines.Select(l => l.Product));
            if (order.OrderId == 0)
            {
                ctx.Orders.Add(order);
            }
            ctx.SaveChanges();  
        }

        public List<OrderHeader> Search(bool? Shipped)
        {
            var orders = ctx.Orders.Where(o => !Shipped.HasValue || o.Shipped == Shipped.Value).
                Select(o => new OrderHeader
                {
                    City = o.City,
                    State = o.State,
                    Shipped = o.Shipped,
                    Line1 = o.Line1,
                    Name = o.Name,
                    OrderID = o.OrderId,
                    PaymentId = o.PaymentId,
                    TotalPrice = o.lines.Sum(d => d.Product.Price),
                    PaymentDate = o.PaymentDate,
                }).ToList();
            return orders;
        }

        public void SetPaymentDone(string factorNumber)
        {
           var order = ctx.Orders.Find(int.Parse(factorNumber));
            if (order != null)
            {
                order.PaymentDate = DateTime.Now;
                ctx.SaveChanges();
            }
        }

        public void SetTransactionId(int orderId, string token)
        {
            var order = ctx.Orders.Find(orderId);
            if (order != null)
            {
                order.PaymentId = token;
                ctx.SaveChanges();
            }
        }

        public void Ship(int orderId)
        {
            var order = ctx.Orders.Find(orderId);
            if (order != null)
            {
                order.Shipped = true;
                ctx.SaveChanges();
            }
        }
    }
}
