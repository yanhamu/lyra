using Lyra.DataAccess.Repositories;
using StructureMap;

namespace Lyra.Web.Configuration.IoC
{
    public class DataAccessRegistry : Registry
    {
        public DataAccessRegistry()
        {
            this.Scan(c =>
            {
                c.AssemblyContainingType<PlayerRepository>();
                c.WithDefaultConventions();
            });
        }
    }
}
