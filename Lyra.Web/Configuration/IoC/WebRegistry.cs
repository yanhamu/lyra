using Lyra.Web.Services;
using StructureMap;

namespace Lyra.Web.Configuration.IoC
{
    public class WebRegistry : Registry
    {
        public WebRegistry()
        {
            this.Scan(c =>
            {
                c.AssemblyContainingType<IUserIdProvider>();
                c.WithDefaultConventions();
            });

        }
    }
}
