namespace Dao.Interface
{
    public interface IClientDao<TEntity>
    {
        List<TEntity> GetList();
        TEntity Create(string clientName);
        TEntity GetById(int id);
        TEntity Update(int id, TEntity entityDao);
        TEntity DeleteById(int id);
    }
}
