using CourtDatabase2.Areas.Admin.Models;
using CourtDatabase2.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CourtDatabase2.Services.Contracts
{
    public interface IUsersService
    {
        IEnumerable<KeyValuePair<string, string>> GetAllUsers();

        IEnumerable<KeyValuePair<string, string>> GetAllRoles();

        Task<IEnumerable<UsersAllViewModel>> AllUsersAsync();

        Task<IEnumerable<RolesAllViewModel>> AllRolesAsync();

        Task AddRole(RolesAllViewModel model);

        Task AddUserToRole(AddUserToRoleInputModel model);
        
        Task DeleteRole(string id);

        Task<AddUserToRoleInputModel> GetUserById(string id);
    }
}
