namespace Lyra.DataAccess.Repositories
{
    public interface IRepository<TEntity>
    {
        TEntity Get(params object[] ids);
        int Save();
    }
}
