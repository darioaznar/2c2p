using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace _2C2P___Aznar.Models
{

    /// <summary>
    /// Comments: It would be recommended to add a boolean 'status' , or a datetime DateDeleted to 
    /// be able to use soft deletes
    /// </summary>
    public class Customer
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


        [RegularExpression(@"^[0-9]{10}$", ErrorMessage = "Not a valid phone number")]
        [Required]
        public string Mobile {get;set;}

        public ICollection<Transaction> Transactions { get; set; }

    }
}
