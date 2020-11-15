using CourtDatabase2.ViewModels;
using System.Collections.Generic;

namespace CourtDatabase2.Services.Contracts
{
    public interface IExecutorsCasesService
    {
        IEnumerable<ExecutorsCasesAllViewModel> All();
        ExecutorsCasesEditViewModel Details(int? id);
    }
}
