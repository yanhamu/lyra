using Lyra.DataAccess.Model;
using System;
using System.Linq;

namespace Lyra.DataAccess.Repositories
{
    public interface IRealmRepository : IRepository<Realm>
    {
        Realm GetActiveRealm(DateTime now);
    }

    public class RealmRepository : Repository<Realm>, IRealmRepository
    {
        public RealmRepository(ApplicationDbContext context) : base(context) { }

        public Realm GetActiveRealm(DateTime now)
        {
            return SourceSet
                .Where(r => r.Beginning <= now)
                .Where(r => r.End > now)
                .SingleOrDefault();
        }
    }
}
