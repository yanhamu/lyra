using Lyra.Services.Common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Lyra.Web.Services.Flow
{
    public class MeanwhileRedirectionHandler : RedirectionHandler
    {
        private readonly IRealmService realmService;

        public MeanwhileRedirectionHandler(IRealmService realmService, IRedirectionHandler nextHandler)
        {
            this.realmService = realmService;
            this.NextHandler = nextHandler;
        }

        public override void Handle(ActionExecutingContext context)
        {
            if (this.realmService.GetActiveRealm() == null)
            {
                context.Result = new RedirectToActionResult("Meanwhile", "Dashboard", null);
            }
            else
            {
                this.Next(context);
            }
        }
    }
}