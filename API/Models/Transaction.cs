using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _2C2P___Aznar.Models
{
    /// <summary>
    /// entity object that represents a transaction
    /// </summary>
    public class Transaction
    {
        /// <summary>
        /// I prefer to use enumeration for status as it is friendlier to manipulate
        /// </summary>
        public enum TransactionStatus
        {
            Success = 0,
            Failed = 1,
            Canceled = 2
        }

        /// <summary>
        /// Idem as Status, here an enumeration that would have all diferente currencies codes
        /// </summary>
        public enum TransactionCurrency
        {
            JPY,
            THB,
            USD,
            SGD
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long TransactionID { get; set; }

        [Required]
        [Column(TypeName = "DateTime")]
        public DateTime Date { get; set; }

        [Required]
        [DataType("decimal(18 ,2")]
        public decimal Amount { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(3)")]
        public TransactionCurrency Currency { get; set; }

        [Required]
        public TransactionStatus Status { get; set; }




        public virtual Customer Customer { get; set; }




    }
}
