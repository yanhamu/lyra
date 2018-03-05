using Microsoft.AspNetCore.Mvc;

namespace Lyra.Web.Services.Flow
{
    public  class RedirectToHallOfFame : INextStep
    {
        public IActionResult Execute()
        {
            return new RedirectToActionResult("Index", "HallOfFame", null);
        }
    }
}