using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace _2C2P___Aznar.Models
{

    /// <summary>
    /// I use Dtos in order to separate what is data modeling from data tranfer objects
    /// through api requests
    /// In this scenario the DTOs objects are almost equals to Model Objects, but in my opinion is a good separation of concerns.
    /// The mapping can be set manually, or otherwise through a mapping tool as I'm using in this project (autommapper)
    /// </summary>
    public class CustomerDto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long customerID { get; set; }

        [Required]
        [StringLength(30)]
        public string Name { get; set; }

        [Required]
        [StringLength(25)]
        [EmailAddress]
        public string Email { get; set; }


        [RegularExpression(@"^[0-9]{10}$")]
        [Required]
        public string Mobile {get;set;}

        public ICollection<TransactionDto> Transactions { get; set; }

    }
}
