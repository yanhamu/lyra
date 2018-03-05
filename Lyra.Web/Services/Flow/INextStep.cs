using Microsoft.AspNetCore.Mvc;

namespace Lyra.Web.Services.Flow
{
    public interface INextStep
    {
        IActionResult Execute();
    }
}
