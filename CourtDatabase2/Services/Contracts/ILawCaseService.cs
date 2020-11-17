using CourtDatabase2.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CourtDatabase2.Services.Contracts
{
    public interface ILawCaseService
    {
        Task CreateAsync(LawCaseInputModel model);

        Task<IEnumerable<LawCasesAllViewModel>> AllAsync();

        IEnumerable<KeyValuePair<string, string>> AbNumbers();

        IEnumerable<KeyValuePair<string, string>> Debitors();

        Task<LawCaseViewModel> DetailsAsync(int? id);

        Task DeleteAsync(int? id);

        Task<LawCaseViewModel> EditAsync(int? id);

        Task EditAsync(LawCaseViewModel model);
    }
}
