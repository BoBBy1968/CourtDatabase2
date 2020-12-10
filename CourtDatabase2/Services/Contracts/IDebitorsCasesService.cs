using CourtDatabase2.Areas.DebitorsCases.Models;
using CourtDatabase2.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CourtDatabase2.Services.Contracts
{
    public interface IDebitorsCasesService
    {
        Task<IEnumerable<CaseActionsAllViewModel>> AllActions(int? id);

        Task<IEnumerable<DebitorsCasesAllViewModel>> AllCases();

        Task<IEnumerable<ExpenseAllViewModel>> AllExpenses(int? id);

        Task<IEnumerable<PaymentsAllViewModel>> AllPayments(int? id);

        Task<DebitorsCasesAllViewModel> CaseDetails(int? id);

        Task CreateExpense(ExpenseInputViewModel model);

        Task CreatePayment(PaymentsInputViewModel model);
    }
}
