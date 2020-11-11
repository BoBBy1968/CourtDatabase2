using CourtDatabase2.Data.Models.Enumerations;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CourtDatabase2.Data.Models
{
    public class Payment
    {
        [Key]
        public int Id { get; set; }

        [Range(0, 79228162514264337593543935D)]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Value { get; set; }

        public DateTime Date { get; set; }

        public PaymentSource PaymentSource { get; set; }

        [ForeignKey(nameof(Obligation))]
        public int ObligationId { get; set; }
        public virtual Obligation Obligation { get; set; }
    }
}
