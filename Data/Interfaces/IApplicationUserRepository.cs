using CelilCavus.RepositoryDesiginPattern.Data.Entites;

namespace CelilCavus.RepositoryDesiginPattern.Data.Interfaces
{
    public interface IApplicationUserRepository
    {
        List<ApplicationUser> GetAll();
        ApplicationUser GetById(int id);
    }
}