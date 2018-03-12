using Lyra.Web.Services.Flow;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Lyra.Web.Extensions
{
    public class GameAttribute : ServiceFilterAttribute
    {
        public GameAttribute() : base(typeof(GameFilterAttribute)) { }
    }

    public class GameFilterAttribute : ActionFilterAttribute
    {
        private readonly IRedirectionHandler redirectHandler;

        public GameFilterAttribute(IRedirectionHandler redirectHandler)
        {
            this.redirectHandler = redirectHandler;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            redirectHandler.Handle(context);
        }
    }
}