using System;
using System.ComponentModel.DataAnnotations;

namespace CourtDatabase2.ViewModels
{
    public class LegalActionViewModel
    {
        public int Id { get; set; }

        [MaxLength(50, ErrorMessage = "Съдебното действие може да бъде до 50 знака.")]
        [MinLength(3, ErrorMessage = "Съдебното действие трябва да бъде поне 3 знака.")]
        [Required(ErrorMessage = "Съдебното действие е задължително.")]
        public string ActionName { get; set; }

    }
}
