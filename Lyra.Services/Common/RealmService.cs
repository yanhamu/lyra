using Lyra.DataAccess.Model;
using Lyra.DataAccess.Repositories;

namespace Lyra.Services.Common
{
    public interface IRealmService
    {
        Realm GetActiveRealm();
    }

    public class RealmService : IRealmService
    {
        private readonly IRealmRepository repository;
        private readonly ITimeProvider timeProvider;

        public RealmService(
            IRealmRepository repository,
            ITimeProvider timeProvider)
        {
            this.repository = repository;
            this.timeProvider = timeProvider;
        }

        public Realm GetActiveRealm()
        {
            var now = timeProvider.GetNow();
            return repository.GetActiveRealm(now);
        }
    }
}