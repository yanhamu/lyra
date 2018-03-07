using Lyra.Web.Services;
using StructureMap;

namespace Lyra.Web.Configuration.IoC
{
    public class ServiceRegistry : Registry
    {
        public ServiceRegistry()
        {
            this.Scan(c =>
            {
                c.AssemblyContainingType<IUserIdProvider>();
                c.WithDefaultConventions();
            });

        }
    }
}
