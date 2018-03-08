using Lyra.DataAccess.Model;
using System;
using System.Linq;

namespace Lyra.DataAccess.Repositories
{
    public interface IPlayerRepository : IRepository<Player>
    {
        Player GetPlayerForRealm(Guid userId, Guid id);
    }

    public class PlayerRepository : Repository<Player>, IPlayerRepository
    {
        public PlayerRepository(ApplicationDbContext context) : base(context) { }

        public Player GetPlayerForRealm(Guid userId, Guid realmId)
        {
            return SourceSet
                .Where(p => p.UserId == userId)
                .Where(p => p.RealmId == realmId)
                .SingleOrDefault();
        }
    }
}