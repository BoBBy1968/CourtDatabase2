using CourtDatabase2.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CourtDatabase2.Services.Contracts
{
    public interface ILawCaseService
    {
        IEnumerable<KeyValuePair<string, string>> AbNumbers();

        IEnumerable<KeyValuePair<string, string>> Debitors();

        Task<IEnumerable<LawCasesAllViewModel>> AllAsync();

        Task CreateAsync(LawCaseInputModel model);

        //Task<LawCaseViewModel> EditAsync(int? id);

        Task EditAsync(LawCaseViewModel model);

        Task<LawCaseViewModel> DetailsAsync(int? id);

        Task DeleteAsync(int? id);
    }
}
