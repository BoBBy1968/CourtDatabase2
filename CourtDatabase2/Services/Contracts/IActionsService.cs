using CourtDatabase2.ViewModels;
using System.Threading.Tasks;

namespace CourtDatabase2.Services.Contracts
{
    public interface IActionsService
    {
        //Task Application410(CaseActionsCreateViewModel model);

        Task CreateActionReport(CaseActionsCreateViewModel model);
    }
}
