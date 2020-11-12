using CourtDatabase2.ViewModels;
using System.Collections.Generic;

namespace CourtDatabase2.Services
{
    public interface IPaymentsService
    {
        IEnumerable<PaymentsAllViewModel> All();

        IEnumerable<KeyValuePair<string, string>> AllLawCasesId();
        void Create(PaymentsInputViewModel model);
        PaymentsEditViewModel Details(int? id);
        void Edit(PaymentsEditViewModel model);
        PaymentsEditViewModel ToEdit(int? id);
    }
}
