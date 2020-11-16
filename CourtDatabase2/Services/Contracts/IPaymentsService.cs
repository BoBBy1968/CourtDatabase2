using CourtDatabase2.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CourtDatabase2.Services.Contracts
{
    public interface IPaymentsService
    {
        IEnumerable<PaymentsAllViewModel> All();

        IEnumerable<KeyValuePair<string, string>> AllLawCasesId();
        Task CreateAsync(PaymentsInputViewModel model);
        void Delete(int? id);
        PaymentsEditViewModel Details(int? id);
        void Edit(PaymentsEditViewModel model);
        PaymentsEditViewModel ToEdit(int? id);
    }
}
