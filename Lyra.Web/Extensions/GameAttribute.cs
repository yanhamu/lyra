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
        private readonly PlayerRepository repository;

        public GameFilterAttribute(PlayerRepository repository)
        {
            this.repository = repository;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var userId = Guid.Parse(context.HttpContext.User.Identity.Name);

            var player = repository.GetActivePlayer(userId);
            if (player == null)
            {
                context.Result = new RedirectToActionResult("Index", "NationSetup", null);
            }
        }
    }
}
