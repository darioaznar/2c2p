using System.ComponentModel.DataAnnotations;

namespace _2C2P___Aznar.Models
{
    /// <summary>
    /// entity object representing reques criterias
    /// </summary>
    public class InquiryCriteria
    {

        public long? CustomerID { get; set; }


        [StringLength(25)]
        [EmailAddress]
        public string Email { get; set; }

    }
}
