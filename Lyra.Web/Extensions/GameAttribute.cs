using Lyra.Web.Services;
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
        private readonly IUserIdProvider userIdProvider;
        private readonly INextStepCommandFactory nextStepCommandFactory;

        public GameFilterAttribute(
            IUserIdProvider userIdProvider,
            INextStepCommandFactory nextStepCommandFactory)
        {
            this.userIdProvider = userIdProvider;
            this.nextStepCommandFactory = nextStepCommandFactory;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var userId = userIdProvider.Get(context.HttpContext);
            var command = nextStepCommandFactory.Create(userId);

            var result = command.Execute();
            if (result != null)
            {
                context.Result = result;
            }
        }
    }
}