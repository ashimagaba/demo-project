using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using order.ErrorHandling;
using order.Models;

namespace order.Controllers
{
    [Produces("application/json")]
    [Route("api/CustomerDetails")]
    public class CustomerDetailsController : Controller
    {
        private readonly SlipCartDatabaseContext db;
        public CustomerDetailsController(SlipCartDatabaseContext context)
        {
            db = context;
        }

        [HttpGet]
        [Route("{id}")]
        [MyExceptionFilter]
        public IActionResult GetCustomer([FromRoute]int id)
        {

            Customers customer=db.Customers.Find(id);
            if (customer != null)
                return Ok(customer);
            else
                return NotFound();
            
            
                
        }
    }
}
