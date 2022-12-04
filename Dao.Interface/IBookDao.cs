namespace Dao.Interface
{
    public interface IBookDao
    {
        List<TEntity> GetList();
        TEntity Create(TEntity entityDao);
        TEntity GetById(string id);
        Entity Update(string id, TEntity entityDao);
        TEntity DeleteById(string id);
    }
}
