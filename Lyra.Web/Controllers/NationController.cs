using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Lyra.Web.Controllers
{
    [Authorize]
    public class NationController : Controller
    {
        [HttpGet]
        public IActionResult Setup()
        {
            return View(new CountryViewModel());
        }

        [HttpPost]
        public IActionResult Setup(CountryViewModel model)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Index", "Dashboard");
            }
            return View(model);
        }
    }

    public class CountryViewModel
    {
        [Required]
        public string Name { get; set; }
    }
}
