using Lyra.DataAccess.Model;
using Lyra.DataAccess.Repositories;
using System;

namespace Lyra.Services.Common
{
    public interface IRealmService
    {
        bool IsValid(Guid realmId);
    }

    public class RealmService : IRealmService
    {
        private readonly IRepository<Realm> repository;
        private readonly ITimeProvider timeProvider;

        public RealmService(
            IRepository<Realm> repository,
            ITimeProvider timeProvider)
        {
            this.repository = repository;
            this.timeProvider = timeProvider;
        }

        public bool IsValid(Guid realmId)
        {
            var now = timeProvider.GetNow();
            var realm = repository.Get(realmId);
            return realm.Beginning < now & now <= realm.End;
        }
    }
}
