using Lyra.DataAccess.Model;

namespace Lyra.DataAccess.Repositories
{
    public class RealmRepository : Repository<Realm>
    {
        public RealmRepository(ApplicationDbContext context) : base(context) { }
    }
}