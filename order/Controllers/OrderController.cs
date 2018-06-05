using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http.ModelBinding;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using order.ErrorHandling;
using order.Models;
namespace order.Controllers
{
    [Produces("application/json")]
    [Route("api/Order")]
    public class OrderController : Controller
    {
        SlipCartDatabaseContext context;
        OrderAndInvoice data;
        public OrderController(SlipCartDatabaseContext context)
        {
            this.context = context;
            data = new OrderAndInvoice(context);
        }
        
        [HttpPost]
        [MyExceptionFilter]
        public IActionResult AddToDatabase([FromBody]OrderedProducts products)
        {
            string[] result;
            try
            {
                result = data.PostForOrderInvoice(products);
                return Ok(result);
            }
            catch(Exception exception)
            {
                ModelStateDictionary dictionary = new ModelStateDictionary();              
                
                dictionary.AddModelError("Error", exception.Message);
                return BadRequest(dictionary);
            }
         
        }
       

       
        
        
    }
}
