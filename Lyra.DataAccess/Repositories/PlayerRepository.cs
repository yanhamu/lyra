using Lyra.DataAccess.Model;
using System;
using System.Linq;

namespace Lyra.DataAccess.Repositories
{
    public class PlayerRepository : Repository<Player>
    {
        public PlayerRepository(ApplicationDbContext context) : base(context) { }

        public Player GetActivePlayer(Guid userId)
        {
            return this.SourceSet
                .Where(p => p.UserId == userId)
                .Where(p => p.IsActive)
                .SingleOrDefault();
        }
    }
}
