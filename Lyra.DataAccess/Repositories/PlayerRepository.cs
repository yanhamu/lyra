using Lyra.DataAccess.Model;
using System;

namespace Lyra.DataAccess.Repositories
{
    public class PlayerRepository
    {
        private readonly ApplicationDbContext context;

        public PlayerRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public Player Get(Guid playerId)
        {
            return context.Players.Find(playerId);
        }
    }
}