namespace CelilCavus.RepositoryDesiginPattern.Data.Interfaces
{
    public interface IRepository<T> where T : class, new()
    {
        void Create(T item);
        void Remove(T item);
        void Update(T item);
        List<T> GetAll(bool isNoTracking = false);
        T GetById(int id);

        IQueryable<T> GetQueryable();
    }
}