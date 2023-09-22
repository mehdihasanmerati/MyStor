using Microsoft.Extensions.Configuration;
using MyStor.Core.Contracts.Payments;
using MyStor.Core.Domain.Payments;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MyStor.Services.ApplicationServices.Payments
{
    public class PayIrPaymentServices : PaymentService
    {
        private IConfiguration configuration;

        public PayIrPaymentServices(IConfiguration configuration )
        {
            this.configuration = configuration;
        }
        public RequestPaymentRsult RequestPayment(string amount, string mobile, string factorNumber, string description, string validCardNumber)
        {
            HttpClient client = new HttpClient();
            Dictionary<string, string> post_values = new Dictionary<string, string>();
            post_values.Add("api", configuration["PayIr:ApiKey"]);
            post_values.Add("amount", amount.ToString());
            post_values.Add("redirect", configuration["PayIr:RedirectUrl"]);
            post_values.Add("mobile", mobile);
            post_values.Add("factorNumber", factorNumber);
            post_values.Add("description", description);
            post_values.Add("validCardNumber", validCardNumber);
            var content = new FormUrlEncodedContent(post_values);
            var response = client.PostAsync(configuration["PayIr:SendRequestUrl"], content).Result;

            var responseString = response.Content.ReadAsStringAsync().Result;

            return JsonConvert.DeserializeObject<RequestPaymentRsult>(responseString);
            
        }

        public VerifyPaymentRsult VerifyPayment(string token)
        {
            HttpClient client = new HttpClient();
            Dictionary<string, string> post_values = new Dictionary<string, string>();
            post_values.Add("api", configuration["PayIr:ApiKey"]);
            post_values.Add("token", token);
            var content = new FormUrlEncodedContent(post_values);
            var response = client.PostAsync(configuration["PayIr:VerifyUrl"], content).Result;
            var responseString = response.Content.ReadAsStringAsync().Result;
            return JsonConvert.DeserializeObject<VerifyPaymentRsult>(responseString);
        }
    }
}
