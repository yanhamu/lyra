using Lyra.DataAccess.Repositories;
using Lyra.Services.Common;
using System;

namespace Lyra.Web.Services.Flow
{
    public interface INextStepCommandFactory
    {
        INextStep Create(Guid userId);
    }

    public class NextStepCommandFactory
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
            var player = playerRepository.GetActivePlayer(userId);

            if (player == null)
            {
                return new RedirectToHallOfFame();
            }

            if (!realmService.IsValid(player.RealmId))
            {
                return new DeactivatePlayerAndRedirectToHallOfFame(playerRepository, player, new RedirectToHallOfFame());
            }

            return new NullCommand();
        }
    }
}
