using CourtDatabase2.ViewModels;
using System;
using System.Collections.Generic;

namespace CourtDatabase2.Services.Contracts
{
    public interface ICourtService
    {
        IEnumerable<CourtAllViewModel> All();

        void Create(string courtType, int courtTownId);

        public CourtEditViewModel Edit(int? id);

        void Edit(int id, string courtType, int courtTownId);
    }
}
