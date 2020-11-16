using CourtDatabase2.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CourtDatabase2.Services.Contracts
{
    public interface IExpenseService
    {
        IEnumerable<ExpenseAllViewModel> All();

        Task CreateAsync(ExpenseInputViewModel model);

        ExpenseEditViewModel Edit(int? id);

        void Edit(ExpenseEditViewModel model);

        ExpenseEditViewModel Details(int? id);

        ExpenseEditViewModel Delete(int? id);

        void DeleteConfirm(int? id);

        IEnumerable<KeyValuePair<string, string>> GetAllLawCases();
    }
}
