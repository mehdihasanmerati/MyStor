using MyStor.Core.Domain.Payments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStor.Core.Contracts.Payments
{
    public interface PaymentService
    {
        RequestPaymentRsult RequestPayment(string amount, string mobile, string factorNumber, string description, string validCardNumber);
        VerifyPaymentRsult VerifyPayment(string token);

    }
}
