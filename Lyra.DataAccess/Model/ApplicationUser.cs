using Microsoft.AspNetCore.Identity;
using System;

namespace Lyra.DataAccess.Model
{
    public class ApplicationUser : IdentityUser<Guid> { }
    public class Role : IdentityRole<Guid> { }
}
