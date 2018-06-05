using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace order.ErrorHandling
{
    public class MyExceptionFilter : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext exceptionContext)
        {
            exceptionContext.HttpContext.Response.ContentType = "Application/json";
            string str = exceptionContext.Exception.Message;
            exceptionContext.Result = new JsonResult(str);
        }



    }

}
