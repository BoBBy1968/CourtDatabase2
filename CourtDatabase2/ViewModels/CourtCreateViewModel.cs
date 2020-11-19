using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CourtDatabase2.ViewModels
{
    public class CourtCreateViewModel
    {
        [Required]
        [Display(Name = "Вид съд")]
        public string CourtType { get; set; }

        public int CourtTownId { get; set; }

        public IEnumerable<KeyValuePair<string, string>> Towns { get; set; }

    }
}
