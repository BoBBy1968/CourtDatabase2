﻿using CourtDatabase2.ViewModels;
using System.Collections.Generic;

namespace CourtDatabase2.Services
{
    public interface ILawCaseService
    {
        void Create(LawCaseInputModel model);

        IEnumerable<AllLawCasesViewModel> All();

        IEnumerable<KeyValuePair<string, string>> AbNumbers();
        IEnumerable<KeyValuePair<string, string>> Debitors();

        
    }
}