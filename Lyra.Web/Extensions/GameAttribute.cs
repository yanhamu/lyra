using Lyra.DataAccess.Repositories;
using Lyra.Web.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Lyra.Web.Extensions
{
    public class Game : ServiceFilterAttribute
    {
        public Game() : base(typeof(GameFilterAttribute)) { }
    }

    public class GameFilterAttribute : ActionFilterAttribute
    {
        private readonly PlayerRepository repository;
        private readonly IUserIdProvider userIdProvider;

        public GameFilterAttribute(PlayerRepository repository, IUserIdProvider userIdProvider)
        {
            this.repository = repository;
            this.userIdProvider = userIdProvider;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var userId = userIdProvider.Get(context.HttpContext);
            var player = repository.GetActivePlayer(userId);
            if (player == null)
            {
                context.Result = new RedirectToActionResult("Index", "NationSetup", null);
            }
        }
    }
}