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

        LawCaseViewModel Details(int? id);

        void Delete(int? id);
        LawCaseViewModel Edit(int? id);
        void Edit(LawCaseViewModel model);
    }
}
