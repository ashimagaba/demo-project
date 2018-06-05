using order.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace OrderAndInvoice.Models
{
    public class CustomerDetails
    {
        public CustomerDetails()
        {

        }
        public Customer GetCustomerById(int CustomerId)
        {
            Customer Customer=null;
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:58639/api/");
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            string address = $"CustomerDetails/{CustomerId}";
            HttpResponseMessage response = client.GetAsync(address).Result;
            if (response.IsSuccessStatusCode)
            {
                Customer= response.Content.ReadAsAsync<Customer>().Result;
            }
            return Customer;
            


        }
    }
}