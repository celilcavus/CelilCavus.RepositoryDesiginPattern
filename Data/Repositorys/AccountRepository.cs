using CelilCavus.RepositoryDesiginPattern.Data.Context;
using CelilCavus.RepositoryDesiginPattern.Data.Entites;
using CelilCavus.RepositoryDesiginPattern.Data.Interfaces;

namespace CelilCavus.RepositoryDesiginPattern.Data.Repository
{
    public class AccountRepository:IAccountRepository
    {
        private readonly BankContext _context;

        public AccountRepository(BankContext context)
        {
            _context = context;
        }

        public void Create(Account account)
        {
            _context.Accounts.Add(account);
            _context.SaveChanges();
        }
    }
}