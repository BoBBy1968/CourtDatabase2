﻿using CourtDatabase2.Data.Models;
using CourtDatabase2.ViewModels;
using System.Collections.Generic;

namespace CourtDatabase2.Services.Contracts
{
    public interface ICourtTownService
    {
        void Create(string townName, string address);

        IEnumerable<EditCourtTownViewModel> All();

        CourtTown Details(int id);

        void Delete(int id);
        
        CourtTown Edit(int id);

        void Edit(string townName, string address, int id);
    }
}