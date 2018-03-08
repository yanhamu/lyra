using Lyra.DataAccess;
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
                c.AddAllTypesOf(typeof(IRepository<>));
                c.WithDefaultConventions();
                c.ExcludeType<ApplicationDbContext>();
            });

            For<ApplicationDbContext>().Transient();


        }
    }
}
