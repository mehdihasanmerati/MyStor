using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStor.Core.Domain.Payments
{
    public class RequestPaymentRsult
    {
        public int Status { get; set; }
        public string Token { get; set; }
        public string errorCode { get; set; }
        public string errorMessage { get; set; }
        public bool IsCorrect => Status == 1;
    }
    public class VerifyPaymentRsult
    {
        public int Status { get; set; }
        public string amount { get; set; }
        public string transId { get; set; }
        public string factorNumber { get; set; }
        public string mobile { get; set; }
        public string description { get; set; }
        public string cardNumber { get; set; }
        public string message { get; set; }
        public string errorCode { get; set; }
        public string errorMessage { get; set; }
        public bool IsCorrect => Status == 1;
    }
}
