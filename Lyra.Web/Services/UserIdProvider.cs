using Lyra.DataAccess.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;

namespace Lyra.Web.Services
{
    public interface IUserIdProvider
    {
        Guid Get(HttpContext context);
    }

    public class UserIdProvider : IUserIdProvider
    {
        private readonly UserManager<ApplicationUser> userManager;

        public UserIdProvider(UserManager<ApplicationUser> userManager)
        {
            this.userManager = userManager;
        }

        public Guid Get(HttpContext context)
        {
            var useriId = userManager.GetUserId(context.User);
            return Guid.Parse(useriId);
        }
    }
}
