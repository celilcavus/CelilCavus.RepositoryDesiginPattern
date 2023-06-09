using CelilCavus.RepositoryDesiginPattern.Data.Context;
using CelilCavus.RepositoryDesiginPattern.Data.Entites;
using CelilCavus.RepositoryDesiginPattern.Data.Interfaces;

namespace CelilCavus.RepositoryDesiginPattern.Data.Repository
{
    public class ApplicationUserRepository : IApplicationUserRepository
    {
        private readonly BankContext _context;

        public ApplicationUserRepository(BankContext context)
        {
            _context = context;
        }

        public List<ApplicationUser> GetAll()
        {
            return _context.ApplicationUsers.ToList();
        }
          public ApplicationUser GetById(int id)
        {
            return _context.ApplicationUsers.SingleOrDefault(x=>x.Id == id);
        }
    }
}