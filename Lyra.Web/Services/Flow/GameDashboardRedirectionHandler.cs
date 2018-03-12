using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Lyra.Web.Services.Flow
{
    public class GameDashboardRedirectionHandler : IRedirectionHandler
    {
        public void Handle(ActionExecutingContext context)
        {
            context.Result = new RedirectToActionResult("Index", "Dashboard", null);
        }
    }
}
