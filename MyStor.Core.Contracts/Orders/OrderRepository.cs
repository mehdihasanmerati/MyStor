using MyStor.Core.Domain.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStor.Core.Contracts.Orders
{
    public interface OrderRepository
    {
        void SaveOrder(Order order);
        Order Find(int id);
        void SetTransactionId(int orderId, string token);
        void SetPaymentDone(string factorNumber);
    }
}
