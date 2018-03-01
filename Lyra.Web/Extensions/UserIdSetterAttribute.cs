using Microsoft.AspNetCore.Mvc.Filters;
using System;

namespace Lyra.Web.Extensions
{
    public class UserIdSetterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (context.Controller is IUserSet userSet)
            {
                userSet.UserId = Guid.Parse(context.HttpContext.User.Identity.Name);
            }
        }
    }

    public interface IUserSet
    {
        Guid UserId { get; set; }
    }
}
