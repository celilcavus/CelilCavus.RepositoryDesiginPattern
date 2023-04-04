using CelilCavus.RepositoryDesiginPattern.Data.Entites;
using CelilCavus.RepositoryDesiginPattern.Models;

namespace CelilCavus.RepositoryDesiginPattern.Mapping
{
    public class UserMapper : IUserMapper
    {
        public List<UserListModel> MapToListOfUserList(List<ApplicationUser> users)
        {
            return users.Select(x => new UserListModel
            {
                Id = x.Id,
                Name = x.Name,
                LastName = x.LastName
            }).ToList();
        }
        public UserListModel MapToListOfUserList(ApplicationUser users)
        {
            return new UserListModel
            {
                Id = users.Id,
                Name = users.Name,
                LastName = users.LastName
            };
        }
    }
}