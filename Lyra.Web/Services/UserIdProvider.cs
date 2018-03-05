using Microsoft.AspNetCore.Http;
using System;

namespace Lyra.Web.Services
{
    public interface IUserIdProvider
    {
        Guid Get(HttpContext context);
    }

    public class UserIdProvider
    {
        public Guid Get(HttpContext context)
        {
            return Guid.Parse(context.User.Identity.Name);
        }
    }
}
