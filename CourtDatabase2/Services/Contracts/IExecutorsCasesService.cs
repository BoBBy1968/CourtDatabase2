using CourtDatabase2.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CourtDatabase2.Services.Contracts
{
    public interface IExecutorsCasesService
    {
        IEnumerable<KeyValuePair<string, string>> GetAllLawCases();

        IEnumerable<KeyValuePair<string, string>> GetAllExecutors();

        Task<IEnumerable<ExecutorsCasesAllViewModel>> AllAsync();
        
        Task CreateAsync(ExecutorsCasesCreateViewModel model);

        Task EditAsync(ExecutorsCasesEditViewModel model);
        
        Task<ExecutorsCasesEditViewModel> DetailsAsync(int? id);
        
        Task DeleteAsync(int? id);
    }
}
