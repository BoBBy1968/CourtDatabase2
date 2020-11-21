using CourtDatabase2.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CourtDatabase2.Services.Contracts
{
    public interface IInvoicesService
    {
        IEnumerable<KeyValuePair<string, string>> GetAllEstates();

        //IEnumerable<KeyValuePair<string, string>> GetAllDebitors();

        Task<IEnumerable<InvoicesAllViewModel>> AllAsync();

        Task CreateAsync(InvoicesCreateViewModel model);

        Task EditAsync(InvoicesEditViewModel model);

        Task<InvoicesEditViewModel> DetailsAsync(int? id);

        Task DeleteAsync(int? id);
    }
}
