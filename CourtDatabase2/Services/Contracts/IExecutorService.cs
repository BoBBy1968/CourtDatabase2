using CourtDatabase2.ViewModels;
using System.Collections.Generic;

namespace CourtDatabase2.Services.Contracts
{
    public interface IExecutorService
    {
        IEnumerable<ExecutorsAllViewModel> All();

        void Create(ExecutorsCreateViewModel model);

        void Delete(int? id);

        ExecutorsEditViewModel Details(int? id);

        void Edit(ExecutorsEditViewModel model);
    }
}
