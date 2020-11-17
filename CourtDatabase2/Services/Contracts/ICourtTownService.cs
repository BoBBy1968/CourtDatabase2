using CourtDatabase2.Data.Models;
using CourtDatabase2.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CourtDatabase2.Services.Contracts
{
    public interface ICourtTownService
    {
        Task CreateAsync(string townName, string address);

        Task<IEnumerable<CourtTownEditViewModel>> AllAsync();

        Task<CourtTown> DetailsAsync(int? id);

        Task DeleteAsync(int? id);

        Task<CourtTown> EditAsync(int? id);

        Task EditAsync(string townName, string address, int id);
    }
}
