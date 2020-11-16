using CourtDatabase2.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CourtDatabase2.Services.Contracts
{
    public interface ICourtService
    {
        IEnumerable<CourtAllViewModel> All();

        Task CreateAsync(string courtType, int courtTownId);

        public CourtEditViewModel Edit(int? id);

        void Edit(int id, string courtType, int courtTownId);
    }
}
