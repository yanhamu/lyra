using Lyra.DataAccess.Model;
using Lyra.DataAccess.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Lyra.Web.Services.Flow
{
    public class RealmEnded : INextStep
    {
        private IPlayerRepository playerRepository;
        private Player player;

        public RealmEnded(IPlayerRepository playerRepository, Player player)
        {
            this.playerRepository = playerRepository;
            this.player = player;
        }

        public IActionResult Execute()
        {
            player.IsActive = false;
            playerRepository.Save();

            return new RedirectToActionResult("Index", "HallOfFame", null);
        }
    }
}