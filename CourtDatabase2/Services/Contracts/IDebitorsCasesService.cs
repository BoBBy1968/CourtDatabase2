using CourtDatabase2.Areas.DebitorsCases.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CourtDatabase2.Services.Contracts
{
    public interface IDebitorsCasesService
    {
        Task<IEnumerable<DebitorsCasesAllViewModel>> AllCases();

        Task<DebitorsCasesAllViewModel> CaseDetails(int? id);
    }
}
