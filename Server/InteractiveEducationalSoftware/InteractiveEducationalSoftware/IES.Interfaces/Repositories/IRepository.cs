namespace IES.Interfaces.Repositories
{
    public interface IRepository<T, TKey>
    {
        List<T> SelectAll();
        T SelectById(TKey id);
        void Insert(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
