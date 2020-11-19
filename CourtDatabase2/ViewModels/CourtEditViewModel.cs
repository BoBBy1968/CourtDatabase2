using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CourtDatabase2.ViewModels
{
    public class CourtEditViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Вид съд")]
        public string CourtType { get; set; }

        [Display(Name = "Град")]
        public string Town { get; set; }

        public int CourtTownId { get; set; }

        public IEnumerable<KeyValuePair<string, string>> Towns { get; set; }
    }
}
