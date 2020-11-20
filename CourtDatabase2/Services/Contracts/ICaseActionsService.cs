using CourtDatabase2.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CourtDatabase2.Services.Contracts
{
    public interface ICaseActionsService
    {
        IEnumerable<KeyValuePair<string, string>> GetAllLegalActions();

        IEnumerable<KeyValuePair<string, string>> GetAllLawCases();

        Task<IEnumerable<CaseActionsAllViewModel>> AllAsync();

        Task CreateAsync(CaseActionsCreateViewModel model);

        Task EditAsync(CaseActionsEditViewModel model);

        Task<CaseActionsEditViewModel> DetailsAsync(int? id);

        Task DeleteConfirm(int? id);
    }
}
