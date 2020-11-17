using CourtDatabase2.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CourtDatabase2.Services.Contracts
{
    public interface IExecutorsCasesService
    {
        Task<IEnumerable<ExecutorsCasesAllViewModel>> AllAsync();
        
        Task<ExecutorsCasesEditViewModel> DetailsAsync(int? id);
        
        Task CreateAsync(ExecutorsCasesCreateViewModel model);
        
        Task DeleteAsync(int? id);

        IEnumerable<KeyValuePair<string, string>> GetAllLawCases();

        IEnumerable<KeyValuePair<string, string>> GetAllExecutors();

        Task EditAsync(ExecutorsCasesEditViewModel model);
    }
}
