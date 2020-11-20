using CourtDatabase2.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CourtDatabase2.Services.Contracts
{
    public interface ILegalActionService
    {
        Task<IEnumerable<LegalActionViewModel>> AllAsync();

        Task CreateAsync(LegalActionInputModel model);

        Task EditAsync(LegalActionViewModel model);

        Task<LegalActionViewModel> DetailsAsync(int? id);

        Task DeleteConfirm(int? id);
    }
}
