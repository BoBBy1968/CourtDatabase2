using CourtDatabase2.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CourtDatabase2.Services.Contracts
{
    public interface IExpenseService
    {
        Task<IEnumerable<ExpenseAllViewModel>> AllAsync();

        Task CreateAsync(ExpenseInputViewModel model);

        //Task<ExpenseEditViewModel> Edit(int? id);

        Task Edit(ExpenseEditViewModel model);

        Task<ExpenseEditViewModel> DetailsAsync(int? id);

        Task<ExpenseEditViewModel> Delete(int? id);

        Task DeleteConfirm(int? id);

        IEnumerable<KeyValuePair<string, string>> GetAllLawCases();
    }
}
