using Lyra.DataAccess.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;

namespace Lyra.Web.Extensions
{
    public class GameAttribute : ActionFilterAttribute
    {
        private readonly PlayerRepository playerRepository;

        public GameAttribute(PlayerRepository playerRepository)
        {
            this.playerRepository = playerRepository;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var playerId = context.HttpContext.Request.Cookies["pid"];
            if (playerId == null)
            {
                context.Result = new RedirectToActionResult("Index", "NationSetup", null);
            }

            var id = Guid.Parse(playerId);
            var userId = context.HttpContext.User.Identity.Name;

            var player = playerRepository.Get(id);
            if (player.UserId != userId)
            {
                context.Result = new StatusCodeResult(400);
            }
        }
    }
}
