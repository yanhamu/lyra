using Lyra.Services.Common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Lyra.Web.Services.Flow
{
    public class PlayerRegistrationHandler : RedirectionHandler
    {
        private readonly IRealmService realmService;
        private readonly IUserIdProvider userIdProvider;

        public PlayerRegistrationHandler(
            IRealmService realmService,
            IUserIdProvider userIdProvider,
            IRedirectionHandler nextHandler)
        {
            this.realmService = realmService;
            this.userIdProvider = userIdProvider;
            this.NextHandler = nextHandler;
        }

        public override void Handle(ActionExecutingContext context)
        {
            var activeRealm = realmService.GetActiveRealm();
            var userId = userIdProvider.Get(context.HttpContext);
            if (realmService.GetRealmPlayer(userId, activeRealm.Id) == null)
            {
                context.Result = new RedirectToActionResult("Register", "Nation", null);
            }
            else
            {
                this.Next(context);
            }
        }
    }
}
