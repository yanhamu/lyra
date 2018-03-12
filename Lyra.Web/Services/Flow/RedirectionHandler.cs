using Microsoft.AspNetCore.Mvc.Filters;

namespace Lyra.Web.Services.Flow
{
    public abstract class RedirectionHandler : IRedirectionHandler
    {
        protected IRedirectionHandler NextHandler { get; set; }

        public abstract void Handle(ActionExecutingContext context);

        protected void Next(ActionExecutingContext context)
        {
            if (NextHandler != null)
                NextHandler.Handle(context);
        }
    }
}
