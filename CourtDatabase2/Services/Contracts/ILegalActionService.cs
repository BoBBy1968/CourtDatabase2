using CourtDatabase2.ViewModels;
using System;
using System.Collections.Generic;

namespace CourtDatabase2.Services.Contracts
{
    public interface ILegalActionService
    {
        void Create(DateTime date, string actionName);

        IEnumerable<LegalActionViewModel> All();
    }
}
