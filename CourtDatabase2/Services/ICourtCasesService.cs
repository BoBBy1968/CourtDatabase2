using CourtDatabase2.ViewModels;
using System.Collections.Generic;

namespace CourtDatabase2.Services
{
    public interface ICourtCasesService
    {
        IEnumerable<KeyValuePair<string, string>> AllCourts();
        void Create(CourtCasesInputModel model);
    }
}
