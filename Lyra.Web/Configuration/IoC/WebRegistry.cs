using Lyra.Web.Services;
using Lyra.Web.Services.Flow;
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

                c.ExcludeType<IRedirectionHandler>();

                c.WithDefaultConventions();
            });

            For<IRedirectionHandler>().Use<GameDashboardRedirectionHandler>().Transient();
            For<IRedirectionHandler>().DecorateAllWith<PlayerRegistrationHandler>().Transient();
            For<IRedirectionHandler>().DecorateAllWith<MeanwhileRedirectionHandler>().Transient();
        }
    }
}