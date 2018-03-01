using Lyra.DataAccess.Model;
using System;

namespace Lyra.DataAccess.Repositories
{
    public class RealmRepository
    {
        private readonly ApplicationDbContext context;

        public RealmRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public Realm GetRealm(Guid realmId)
        {
            return this.context.Realms.Find(realmId);
        }
    }
}