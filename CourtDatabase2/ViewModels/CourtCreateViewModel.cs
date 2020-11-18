using System.Collections.Generic;

namespace CourtDatabase2.ViewModels
{
    public class CourtCreateViewModel
    {
        public string CourtType { get; set; }

        public int CourtTownId { get; set; }

        public IEnumerable<KeyValuePair<string, string>> Towns { get; set; }

    }
}
