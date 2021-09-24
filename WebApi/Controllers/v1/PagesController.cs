using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Controllers.v1
{
    [Route("dashboard")]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class PagesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
