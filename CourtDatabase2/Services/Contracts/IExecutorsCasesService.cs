using CourtDatabase2.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CourtDatabase2.Services.Contracts
{
    public interface IExecutorsCasesService
    {
        Task<IEnumerable<ExecutorsCasesAllViewModel>> AllAsync();
        
        ExecutorsCasesEditViewModel Details(int? id);
        
        Task CreateAsync(ExecutorsCasesCreateViewModel model);
        
        void Delete(int? id);

        IEnumerable<KeyValuePair<string, string>> GetAllLawCases();

        IEnumerable<KeyValuePair<string, string>> GetAllExecutors();

        void Edit(ExecutorsCasesEditViewModel model);
    }
}
