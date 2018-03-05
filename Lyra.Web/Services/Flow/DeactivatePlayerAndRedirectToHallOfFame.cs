using Lyra.DataAccess.Model;
using Lyra.DataAccess.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Lyra.Web.Services.Flow
{
    public class DeactivatePlayerAndRedirectToHallOfFame : INextStep
    {
        private IPlayerRepository playerRepository;
        private Player player;
        private readonly INextStep nextStep;

        public DeactivatePlayerAndRedirectToHallOfFame(
            IPlayerRepository playerRepository,
            Player player,
            INextStep nextStep)
        {
            this.playerRepository = playerRepository;
            this.player = player;
            this.nextStep = nextStep;
        }

        public IActionResult Execute()
        {
            player.IsActive = false;
            playerRepository.Save();
            return nextStep.Execute();
        }
    }
}