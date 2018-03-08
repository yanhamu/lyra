using Lyra.Services.Common;
using StructureMap;

namespace Lyra.Web.Configuration.IoC
{
    public class ServicesRegistry : Registry
    {
        public ServicesRegistry()
        {
            this.Scan(c =>
            {
                c.AssemblyContainingType<RealmService>();
                c.WithDefaultConventions();
            });
        }
    }
}