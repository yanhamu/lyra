using Microsoft.AspNetCore.Mvc;

namespace Lyra.Web.Services.Flow
{
    public class NullCommand : INextStep
    {
        public IActionResult Execute()
        {
            return null;
        }
    }
}
