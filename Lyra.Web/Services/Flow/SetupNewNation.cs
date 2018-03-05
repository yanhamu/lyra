using Microsoft.AspNetCore.Mvc;

namespace Lyra.Web.Services.Flow
{
    public  class SetupNewNation : INextStep
    {
        public IActionResult Execute()
        {
            return new RedirectToActionResult("Index", "NationSetup", null);
        }
    }
}