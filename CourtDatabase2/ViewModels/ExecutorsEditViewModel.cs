using System.ComponentModel.DataAnnotations;

namespace CourtDatabase2.ViewModels
{
    public class ExecutorsEditViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Името е задължително.")]
        [MaxLength(300, ErrorMessage = "Името може да бъде до 300 знака.")]
        [MinLength(3, ErrorMessage = "Името трябва да бъде поне 3 знака.")]
        public string Name { get; set; }

        [MaxLength(300, ErrorMessage = "Адресът може да бъде до 300 знака.")]
        [MinLength(3, ErrorMessage = "Адресът трябва да бъде поне 3 знака.")]
        [Required(ErrorMessage = "Адресът е задължителен.")]
        public string Address { get; set; }

        [MaxLength(50, ErrorMessage = "Телефонът може да бъде до 50 знака.")]
        [MinLength(6, ErrorMessage = "Телефонът трябва да бъде поне 6 знака.")]
        public string Telephon { get; set; }

        [MaxLength(200, ErrorMessage = "Имейлът може да бъде до 200 знака.")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Номерът е задължителен.")]
        [MaxLength(5, ErrorMessage = "Номерът може да бъде до 5 знака.")]
        [MinLength(3, ErrorMessage = "Номерът трябва да бъде поне 3 знака.")]
        public string Number { get; set; }

        [Required(ErrorMessage = "Регионът е задължителен.")]
        [MaxLength(20, ErrorMessage = "Регионът може да бъде до 20 знака.")]
        [MinLength(3, ErrorMessage = "Регионът трябва да бъде поне 3 знака.")]
        public string Region { get; set; }
    }
}
