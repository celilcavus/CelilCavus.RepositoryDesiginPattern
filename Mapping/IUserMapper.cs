using CelilCavus.RepositoryDesiginPattern.Data.Entites;
using CelilCavus.RepositoryDesiginPattern.Models;

namespace CelilCavus.RepositoryDesiginPattern.Mapping
{
    public interface IUserMapper
    {
        List<UserListModel> MapToListOfUserList(List<ApplicationUser> users);
        UserListModel MapToListOfUserList(ApplicationUser users);
    }
}