using CourtDatabase2.Data.Models.Enumerations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CourtDatabase2.Data.Models
{
    public class Court
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Вид съд")]
        public CourtType CourtType { get; set; }//enum видове съдилища

        [ForeignKey(nameof(CourtTown))]
        public int CourtTownId { get; set; }

        [Display(Name = "Град")]
        public virtual CourtTown CourtTown { get; set; } //град

        public virtual ICollection<CourtCase> Cases => new HashSet<CourtCase>();//колекция от дела в този съд

    }
}