using System.Threading.Tasks;
using System.Collections.Generic;
using CourtDatabase2.ViewModels.Create.CourtTown;

namespace CourtDatabase2.Services
{
    public interface ICreateCourtTownService
    {
        //Task Create(string townName, string address);
        void Create(string townName, string address);

        IEnumerable<CreateCourtTownViewModel> All();
    }
}
