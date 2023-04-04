using CelilCavus.RepositoryDesiginPattern.Data.Interfaces;

namespace CelilCavus.RepositoryDesiginPattern.Data.UnitOfWork
{
    public interface IUnitOfWork
    {
          IRepository<T> GetRepository<T>() where T : class, new();
          void SaveChanges();
    }
}