using Lyra.DataAccess.Model;
using Lyra.DataAccess.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;

namespace Lyra.Web.Extensions
{
    public class Game : ServiceFilterAttribute
    {
        public Game() : base(typeof(GameFilterAttribute)) { }
    }

    public class GameFilterAttribute : ActionFilterAttribute
    {
        private readonly Repository<Player> playerRepository;

        public GameFilterAttribute(Repository<Player> playerRepository)
        {
            this.playerRepository = playerRepository;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var userId = Guid.Parse(context.HttpContext.User.Identity.Name);

            var playerId = context.HttpContext.Request.Cookies["pid"];
            if (playerId == null)
            {
                context.Result = new RedirectToActionResult("Index", "NationSetup", null);
            }

            var id = Guid.Parse(playerId);

            var player = playerRepository.Get(id);
            if (player.UserId != userId)
            {
                context.Result = new StatusCodeResult(400);
            }
        }
    }
}
