using CourtDatabase2.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CourtDatabase2.Services.Contracts
{
    public interface IExecutorService
    {
        Task<IEnumerable<ExecutorsAllViewModel>> AllAsync();

        Task CreateAsync(ExecutorsCreateViewModel model);

        Task DeleteAsync(int? id);

        Task<ExecutorsEditViewModel> DetailsAsync(int? id);

        Task EditAsync(ExecutorsEditViewModel model);
    }
}
