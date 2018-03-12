using Microsoft.AspNetCore.Mvc.Filters;

namespace Lyra.Web.Services.Flow
{
    public interface IRedirectionHandler
    {
        void Handle(ActionExecutingContext context);
    }
}
