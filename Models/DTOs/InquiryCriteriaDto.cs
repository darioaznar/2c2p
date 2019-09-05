using _2C2P___Aznar.Validations;
using FoolProof.Core;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace _2C2P___Aznar.Models
{

    public class InquiryCriteriaDto
    {

        [JsonProperty(NullValueHandling = NullValueHandling.Include)]
        [Range(1, 9999999999, ErrorMessage = "Invalid Customer ID")]
        [RequiredIfEmpty("Email")]
        [ValidateInquiryCriteria]
        public long? CustomerID { get; set; }


        [ValidateInquiryCriteria]
        [StringLength(25)]
        [EmailAddress(ErrorMessage = "Invalid Email")]
        [RequiredIfEmpty("CustomerID")] //requiredIfEmtpy uses FoolProof tool to extend dependent validations
        public string Email { get; set; }


    }

}
