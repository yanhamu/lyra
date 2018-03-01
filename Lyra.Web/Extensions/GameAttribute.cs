using Microsoft.AspNetCore.Mvc.Filters;
using System;

namespace Lyra.Web.Extensions
{
    public class GameAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            throw new NotImplementedException();
        }
    }
}
