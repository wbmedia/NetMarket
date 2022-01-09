using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApi.Errors;

namespace WebApi.Controllers
{
    [Route("errors")]
    public class ErrorController : BaseApiController
    {
        [HttpGet]
        public IActionResult Error(int code)
        {
            return new ObjectResult(new CodeErrorResponse(code));
        }
       
    }
}