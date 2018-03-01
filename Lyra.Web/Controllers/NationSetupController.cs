using Lyra.Services.Features.RegisterCountry;
using Lyra.Web.Extensions;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;

namespace Lyra.Web.Controllers
{
    [Authorize]
    public class NationSetupController : Controller, IUserSet
    {
        private readonly IMediator mediator;
        public Guid UserId { get; set; }

        public NationSetupController(IMediator mediator)
        {
            this.mediator = mediator;
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
                mediator.Send(new RegisterCountryCommand(model.PlayerName, model.CountryName, UserId));
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