using CourtDatabase2.ViewModels;
using System.Collections.Generic;

namespace CourtDatabase2.Services
{
    public interface ILawCaseService
    {
        void Create(LawCaseInputModel model);

        IEnumerable<LawCasesAllViewModel> All();

        IEnumerable<KeyValuePair<string, string>> AbNumbers();
        IEnumerable<KeyValuePair<string, string>> Debitors();

        LawCaseViewModel Details(int? id);

        void Delete(int? id);
        LawCaseViewModel Edit(int? id);
        void Edit(LawCaseViewModel model);
    }
}
