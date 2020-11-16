using CourtDatabase2.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CourtDatabase2.Services.Contracts
{
    public interface IPaymentsService
    {
        Task<IEnumerable<PaymentsAllViewModel>> AllAsync();

        IEnumerable<KeyValuePair<string, string>> AllLawCasesId();

        Task CreateAsync(PaymentsInputViewModel model);

        Task DeleteAsync(int? id);

        Task<PaymentsEditViewModel> DetailsAsync(int? id);

        Task EditAsync(PaymentsEditViewModel model);

        Task<PaymentsEditViewModel> EditAsync(int? id);
    }
}
