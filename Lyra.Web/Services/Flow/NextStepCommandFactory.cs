using Lyra.DataAccess.Repositories;
using Lyra.Services.Common;
using System;

namespace Lyra.Web.Services.Flow
{
    public interface INextStepCommandFactory
    {
        INextStep Create(Guid userId);
    }

    public class NextStepCommandFactory : INextStepCommandFactory
    {
        private readonly IRealmService realmService;
        private readonly IPlayerRepository playerRepository;

        public NextStepCommandFactory(
            IPlayerRepository playerRepository,
            IRealmService realmService)
        {
            this.realmService = realmService;
            this.playerRepository = playerRepository;
        }

        public INextStep Create(Guid userId)
        {
            if (ThereIsActiveRealm() == false)
                return new RedirectToMeanWhile();

            if (ThereIsActivePlayer(userId) == false)
                return new RedirectToRegisterCountry();

            return new NullCommand();
        }

        private bool ThereIsActivePlayer(Guid userId)
        {
            var activeRealm = realmService.GetActiveRealm();

            return playerRepository.GetPlayerForRealm(userId, activeRealm.Id) != null;
        }

        private bool ThereIsActiveRealm()
        {
            return realmService.GetActiveRealm() != null;
        }
    }
}
