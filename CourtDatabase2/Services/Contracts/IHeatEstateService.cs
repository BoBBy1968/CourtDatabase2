using System.Collections.Generic;
using System.Threading.Tasks;
using CourtDatabase2.ViewModels;

namespace CourtDatabase2.Services.Contracts
{
    public interface IHeatEstateService
    {
        Task<IEnumerable<HeatEstateEditViewModel>> AllAsync();

        Task CreateAsync(HeatEstateInputModel model);

        Task EditAsync(HeatEstateEditViewModel model);

        Task<HeatEstateEditViewModel> DetailsAsync(string abNumber);

        Task DeleteAsync(string abNumber);
    }
}
