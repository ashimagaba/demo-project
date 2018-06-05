using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using order.Models;
using OrderAndInvoice.ErrorHandling;
using OrderAndInvoice.Models;

namespace OrderAndInvoice.Controllers
{
    public class OrdersController : Controller
    {
        [MyExceptionFilter]
        public IActionResult Index()
        {
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("http://localhost:58639");
                client.DefaultRequestHeaders.Accept.Add(
                new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                OrderedProducts sales = new OrderedProducts() {
                     CustomerId=1,
                      OrderDate=DateTime.Now,
                       Products=DemoProductContainer.GetProducts()
                };

                string json = JsonConvert.SerializeObject(sales);
                HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage response = client.PostAsync("api/order",content).Result;
                if (response.IsSuccessStatusCode)
                {
                    string[] data = (string[])response.Content.ReadAsAsync(typeof(string[])).Result;
                //    return Invoice(sales, data);
                    CustomerDetails details = new CustomerDetails();
                    Customer customer = details.GetCustomerById(sales.CustomerId);
                    ViewBag.customer = customer.CustomerMailId;
                    ViewBag.OrderInvoice = data;
                    ViewBag.customer = customer;
                    ViewBag.orderdate = sales.OrderDate;
                    return View("Invoice", sales);

                }

                ViewBag.error = response.ReasonPhrase;
                    return View("Error");
                
              

            }
            
        }

        [MyExceptionFilter]
        public IActionResult Invoice(OrderedProducts products,string[] data)
        {
            CustomerDetails details = new CustomerDetails();
            Customer customer=  details.GetCustomerById(products.CustomerId);
            ViewBag.OrderInvoice = data;
            ViewBag.customer = customer;
            return View("Invoice",products);

        }
       /* public IActionResult Invoice(int? id)
        {
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                OrderAndInvoice invoice = context.Movies.Find(id);
                if (movie == null)
                {
                    return HttpNotFound();
                }
                return View(movie);
            }
        }*/
    }

   
}
