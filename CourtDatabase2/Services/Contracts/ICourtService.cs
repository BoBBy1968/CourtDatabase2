using CourtDatabase2.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CourtDatabase2.Services.Contracts
{
    public interface ICourtService
    {
        IEnumerable<KeyValuePair<string, string>> GetAllCourtTowns();

        Task<IEnumerable<CourtAllViewModel>> AllAsync();

        Task CreateAsync(string courtType, int courtTownId);

        Task<CourtEditViewModel> EditAsync(int? id);

        Task EditAsync(int id, string courtType, int courtTownId);
    }
}
