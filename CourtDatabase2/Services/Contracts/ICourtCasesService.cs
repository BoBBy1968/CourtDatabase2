﻿using CourtDatabase2.Data.Models;
using CourtDatabase2.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CourtDatabase2.Services.Contracts
{
    public interface ICourtCasesService
    {
        IEnumerable<KeyValuePair<string, string>> GetAllCourtTypes();
         
        IEnumerable<KeyValuePair<string, string>> GetAllLawCases();

        Task CreateAsync(CourtCasesInputModel model);

        Task<IEnumerable<CourtCasesViewModel>> AllAsync();

        Task<CourtCasesViewModel> DetailsAsync(int? id);

        Task<CourtCasesViewModel> EditAsync(int? id);

        Task EditAsync(CourtCasesViewModel model);

        Task<CourtCase> Delete(int? id);

        Task DeleteAsync(int? id);
    }
}
