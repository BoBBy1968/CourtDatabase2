using CourtDatabase2.ViewModels;
using System.Collections.Generic;

namespace CourtDatabase2.Services.Contracts
{
    public interface IExecutorsCasesService
    {
        IEnumerable<ExecutorsCasesAllViewModel> All();
        
        ExecutorsCasesEditViewModel Details(int? id);
        
        void Create(ExecutorsCasesCreateViewModel model);
        
        void Delete(int? id);

        IEnumerable<KeyValuePair<string, string>> GetAllLawCases();

        IEnumerable<KeyValuePair<string, string>> GetAllExecutors();
    }
}
