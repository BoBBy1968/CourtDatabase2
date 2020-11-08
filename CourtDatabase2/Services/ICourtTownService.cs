using CourtDatabase2.Data.Models;
using CourtDatabase2.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CourtDatabase2.Services
{
    public interface ICourtTownService
    {
        //Task Create(string townName, string address);
        void Create(string townName, string address);

        IEnumerable<EditCourtTownViewModel> All();

        CourtTown Details(int id);
    }
}
