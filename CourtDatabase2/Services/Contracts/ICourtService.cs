using CourtDatabase2.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CourtDatabase2.Services.Contracts
{
    public interface ICourtService
    {
        Task<IEnumerable<CourtAllViewModel>> AllAsync();

        Task CreateAsync(string courtType, int courtTownId);

        public CourtEditViewModel Edit(int? id);

        void Edit(int id, string courtType, int courtTownId);
    }
}
