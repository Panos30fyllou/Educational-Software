namespace IES.Interfaces.Repositories
{
    public interface ICommonRepository<T, TKey> where T : class
    {
        List<T> SelectAll();
        T SelectById(TKey id);
        int Insert(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
