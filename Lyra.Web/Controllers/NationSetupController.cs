using Lyra.Services.Features.RegisterCountry;
using Lyra.Web.Services;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Lyra.Web.Controllers
{
    [Authorize]
    public class NationSetupController : Controller
    {
        private readonly IMediator mediator;
        private readonly IUserIdProvider userIdProvider;

        public NationSetupController(IMediator mediator,
            IUserIdProvider userIdProvider)
        {
            this.mediator = mediator;
            this.userIdProvider = userIdProvider;
        }


        [HttpGet]
        public IActionResult Index()
        {
            return View(new CountryViewModel());
        }

        [HttpPost]
        public IActionResult Index(CountryViewModel model)
        {
            if (ModelState.IsValid)
            {
                var userId = this.userIdProvider.Get(this.HttpContext);
                mediator.Send(new RegisterCountryCommand(model.PlayerName, model.CountryName, userId));
                return RedirectToAction("Index", "Dashboard");
            }
            return View(model);
        }
    }

    public class CountryViewModel
    {
        [Required(AllowEmptyStrings = false)]
        public string CountryName { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string PlayerName { get; set; }
    }
}