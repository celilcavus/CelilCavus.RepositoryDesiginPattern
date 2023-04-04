using CelilCavus.RepositoryDesiginPattern.Data.Context;
using CelilCavus.RepositoryDesiginPattern.Data.Interfaces;
using CelilCavus.RepositoryDesiginPattern.Data.Repository;

namespace CelilCavus.RepositoryDesiginPattern.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly BankContext _context;

        public UnitOfWork(BankContext context)
        {
            _context = context;
        }

        public IRepository<T> GetRepository<T>() where T : class, new()
        {
            return new Repository<T>(_context);
        }
        public  void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}