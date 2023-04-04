using CelilCavus.RepositoryDesiginPattern.Data.Context;
using CelilCavus.RepositoryDesiginPattern.Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CelilCavus.RepositoryDesiginPattern.Data.Repository
{
    public class Repository<T> : IRepository<T> where T : class, new()
    {
        private readonly BankContext _context;
        private readonly DbSet<T> _set;

        public Repository(BankContext context)
        {
            _context = context;
            _set = _context.Set<T>();
        }

        public void Create(T item)
        {
            _set.Add(item);
          
        }
        public void Remove(T item)
        {
            _set.Remove(item);
            
        }
        public void Update(T item)
        {
            _set.Update(item);
           
        }

        public List<T> GetAll(bool isNoTracking = false)
        {
            return isNoTracking ? _set.AsNoTracking().ToList() : _set.ToList();
        }
        public T GetById(int id)
        {
            return _set.Find(id);
        }

        public  IQueryable<T> GetQueryable()
        {
            return _set.AsQueryable();
        }
    }
}