using CourtDatabase2.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CourtDatabase2.Services.Contracts
{
    public interface IPaymentsService
    {
        IEnumerable<KeyValuePair<string, string>> AllLawCasesId();

        Task<IEnumerable<PaymentsAllViewModel>> AllAsync();

        Task CreateAsync(PaymentsInputViewModel model);

        //Task<PaymentsEditViewModel> EditAsync(int? id);

        Task EditAsync(PaymentsEditViewModel model);

        Task<PaymentsEditViewModel> DetailsAsync(int? id);

        Task DeleteAsync(int? id);
    }
}
