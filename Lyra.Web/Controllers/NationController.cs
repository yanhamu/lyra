using Lyra.Web.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Lyra.Web.Controllers
{
    [Authorize]
    public class NationController : Controller
    {
        [Game]
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(object model)
        {
            throw new NotImplementedException();
        }
    }
}