using CelilCavus.RepositoryDesiginPattern.Data.Entites;
using CelilCavus.RepositoryDesiginPattern.Models;

namespace CelilCavus.RepositoryDesiginPattern.Mapping
{
    public interface IAccountMapper
    {
         Account MapToAccoutn(AccountCreateModel model);
    }
}