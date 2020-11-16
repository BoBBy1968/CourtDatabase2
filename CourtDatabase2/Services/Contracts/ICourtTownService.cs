using CourtDatabase2.Data.Models;
using CourtDatabase2.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CourtDatabase2.Services.Contracts
{
    public interface ICourtTownService
    {
        Task CreateAsync(string townName, string address);

        Task<IEnumerable<CourtTownEditViewModel>> AllAsync();

        CourtTown Details(int? id);

        void Delete(int? id);
        
        CourtTown Edit(int? id);

        void Edit(string townName, string address, int id);
    }
}
