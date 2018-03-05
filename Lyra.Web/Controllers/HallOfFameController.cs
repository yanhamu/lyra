using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Lyra.Web.Controllers
{
    [Authorize]
    public class HallOfFameController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
