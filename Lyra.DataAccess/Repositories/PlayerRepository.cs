using Lyra.DataAccess.Model;

namespace Lyra.DataAccess.Repositories
{
    public class PlayerRepository : Repository<Player>
    {
        public PlayerRepository(ApplicationDbContext context) : base(context) { }
    }
}