using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OrderAndInvoice.ErrorHandling;
using OrderAndInvoice.Services;

namespace MM2.Controllers
{
    public class BankPaymentController : Controller
    {
       
        [HttpGet]
        [MyExceptionFilter]
        public IActionResult MakePayment()
        {

            MakePaymentViewModel model = new MakePaymentViewModel();
            return View(model);
        }
        [HttpPost]
        [MyExceptionFilter]
        public IActionResult MakePayment(MakePaymentViewModel model)
        {
            if (ModelState.IsValid)
            {
                BankService service = new BankService();
                bool result=service.CustomerVerification();
                return RedirectToAction("Index", "Orders");
            }
            return View(model);

            //Create a dummy VerificationService that returns true
           
        }
    }
}