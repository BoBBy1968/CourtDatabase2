using System.Collections.Generic;
using System.Threading.Tasks;
using CourtDatabase2.ViewModels;

namespace CourtDatabase2.Services.Contracts
{
    public interface IDebitorsService
    {
        IEnumerable<KeyValuePair<string, string>> GetAllHeatEstates();

        Task<IEnumerable<DebitorsAllViewModel>> AllAsync();

        Task CreateAsync(DebitorCreateViewModel model);

        //Task<DebitorEditViewModel> EditAsync(int? id);

        Task EditAsync(DebitorEditViewModel model);

        Task<DebitorEditViewModel> DetailsAsync(int? id);

        Task DeleteAsync(int? id);

        Task DeleteAll();
    }
}
