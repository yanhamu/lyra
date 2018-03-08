using Lyra.Web.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Lyra.Web.Controllers
{
    [Authorize]
    public class DashboardController : Controller
    {
        [Game]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Meanwhile()
        {
            return View();
        }
    }
}