using Microsoft.EntityFrameworkCore;

namespace Lyra.DataAccess.Repositories
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly ApplicationDbContext context;
        protected DbSet<TEntity> SourceSet { get; private set; }

        public Repository(ApplicationDbContext context)
        {
            this.context = context;
            this.SourceSet = context.Set<TEntity>();
        }

        public TEntity Get(params object[] ids)
        {
            return SourceSet.Find(ids);
        }
    }
}
