using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using order.ErrorHandling;

namespace order.Controllers
{
    [Produces("application/json")]
    [Route("api/Bank")]
    public class BankController : Controller
    {
        [HttpGet]
        [MyExceptionFilter]
        public IActionResult VerifyCustomer()
        {
            return Ok();
        }
    }
}