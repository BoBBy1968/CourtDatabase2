using CourtDatabase2.Data.Models;
using CourtDatabase2.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CourtDatabase2.Services.Contracts
{
    public interface ICourtCasesService
    {
        IEnumerable<KeyValuePair<string, string>> AllCourts();
        Task CreateAsync(CourtCasesInputModel model);

        IEnumerable<CourtCasesViewModel> All();

        CourtCasesViewModel Details(int? id);

        CourtCasesViewModel Edit(int? id);

        void Edit(CourtCasesViewModel model);

        CourtCase DeleteGet(int? id);

        void DeletePost(int? id);
    }
}
