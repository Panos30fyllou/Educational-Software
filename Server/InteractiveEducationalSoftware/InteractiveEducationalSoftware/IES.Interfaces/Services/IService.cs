namespace IES.Interfaces.Services
{
    public interface IService<T, TKey>
    {
        List<T> SelectAll();
        T SelectById(TKey id);
        void Insert(T entity);
        void Update(T entity);
        void Delete(TKey id);
    }
}
