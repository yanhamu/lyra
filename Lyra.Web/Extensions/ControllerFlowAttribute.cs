using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Linq;

namespace Lyra.Web.Extensions
{
    public class ControllerFlowAttribute : ActionFilterAttribute
    {
        public ControllerFlowAttribute() { }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (ShouldIgnore(context))
            {
                base.OnActionExecuting(context);
                return;
            }

            if (IsInActiveGame(context))
            {
                base.OnActionExecuting(context);
                return;
            }

            if (IsInPreStartGame(context))
            {

            }

            if (ActiveGameExists(context))
            {
                //redirect
                return;
            }

            //redirect
        }

        private bool ActiveGameExists(ActionExecutingContext context)
        {
            throw new NotImplementedException();
        }

        private bool IsInPreStartGame(ActionExecutingContext context)
        {
            throw new NotImplementedException();
        }

        private bool IsInActiveGame(ActionExecutingContext context)
        {
            throw new NotImplementedException();
        }

        private bool ShouldIgnore(ActionExecutingContext context)
        {
            if (context.ActionDescriptor is ControllerActionDescriptor descriptor)
            {
                return descriptor.MethodInfo.GetCustomAttributes(true).Any(a => a.GetType().Equals(typeof(IgnoreControllerFlowAttribute)));
            }
            return false;
        }
    }
}
