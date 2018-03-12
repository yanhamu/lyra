using Lyra.DataAccess.Model;
using Lyra.DataAccess.Repositories;
using System;

namespace Lyra.Services.Common
{
    public interface IRealmService
    {
        Realm GetActiveRealm();
        Player GetRealmPlayer(Guid userId, Guid realmId);
    }

    public class RealmService : IRealmService
    {
        private readonly IRealmRepository repository;
        private readonly ITimeProvider timeProvider;
        private readonly IPlayerRepository playerRepository;

        public RealmService(
            IRealmRepository repository,
            ITimeProvider timeProvider,
            IPlayerRepository playerRepository)
        {
            this.repository = repository;
            this.timeProvider = timeProvider;
            this.playerRepository = playerRepository;
        }

        public Realm GetActiveRealm()
        {
            var now = timeProvider.GetNow();
            return repository.GetActiveRealm(now);
        }

        public Player GetRealmPlayer(Guid userId, Guid realmId)
        {
            return playerRepository.GetPlayerForRealm(userId, realmId);
        }
    }
}