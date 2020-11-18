using System.Collections.Generic;

namespace CourtDatabase2.ViewModels
{
    public class CourtEditViewModel 
    {
        public int Id { get; set; }

        public string CourtType { get; set; }

        public int CourtTownId { get; set; }

        public IEnumerable<KeyValuePair<string, string>> Towns { get; set; }
    }
}
