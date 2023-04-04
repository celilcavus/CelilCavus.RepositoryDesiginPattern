using CelilCavus.RepositoryDesiginPattern.Data.Entites;
using CelilCavus.RepositoryDesiginPattern.Models;

namespace CelilCavus.RepositoryDesiginPattern.Mapping
{
    public class AccountMapper : IAccountMapper
    {
        public Account MapToAccoutn(AccountCreateModel model)
        {
            return new Account
            {
                AccountNumber = model.AccountNumber,
                ApplicationUserId = model.ApplicationUserId,
                Balance = model.Balance  
            };
        }
    }
}