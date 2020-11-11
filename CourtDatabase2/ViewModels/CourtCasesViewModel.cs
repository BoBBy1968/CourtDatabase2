﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourtDatabase2.ViewModels
{
    public class CourtCasesViewModel
    {
        public int Id { get; set; }

        public int CourtId { get; set; }
        public string CourtName { get; set; }


        public int LawCaseId { get; set; }

        public int CaseNumber { get; set; }

        public int CaseYear { get; set; }

        public string CourtChamber { get; set; }

        public string CaseType { get; set; }

    }
}
