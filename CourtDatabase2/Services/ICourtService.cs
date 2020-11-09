using CourtDatabase2.ViewModels;
using System;
using System.Collections.Generic;

namespace CourtDatabase2.Services
{
    public interface ICourtService
    {
        IEnumerable<AllCourtViewModel> All();

        void Create();
    }
}
