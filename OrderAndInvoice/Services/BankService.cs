using OrderAndInvoice.ErrorHandling;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace OrderAndInvoice.Services
{

    public class BankService
    {
        [MyExceptionFilter]
        public bool CustomerVerification()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:58639");
            client.DefaultRequestHeaders.Accept.Add(
            new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage message = client.GetAsync("api/Bank").Result;
            if(message.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }
    }
}
