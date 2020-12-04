using CourtDatabase2.Areas.Admin.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CourtDatabase2.Services.Contracts
{
    public interface IUsersService
    {
        Task AddRole(RolesAllViewModel model);

        Task<IEnumerable<RolesAllViewModel>> AllRolesAsync();
        
        Task<IEnumerable<UsersAllViewModel>> AllUsersAsync();

        Task DeleteRole(string id);
    }
}
