using Lyra.DataAccess.Model;

namespace Lyra.DataAccess.Repositories
{
    public interface IRealmRepository : IRepository<Realm>
    {
    }

    public class RealmRepository : Repository<Realm>, IRealmRepository
    {
        public RealmRepository(ApplicationDbContext context) : base(context) { }
    }
}
