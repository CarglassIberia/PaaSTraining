using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BuyCoffee.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    [ApiExplorerSettings(IgnoreApi = true)]
    public class DefaultController :ControllerBase
    {
        [HttpGet("/")]
        [ApiExplorerSettings(IgnoreApi = true)]
        public IActionResult Swagger()
        {
            return Redirect("/swagger");
        }
    }
}
