using _2C2P___Aznar.Validations;
using FoolProof.Core;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace _2C2P___Aznar.Models
{
   
    public class InquiryCriteriaDto
    {
        
        [JsonProperty(NullValueHandling = NullValueHandling.Include)]
        [Range(1,9999999999,ErrorMessage ="Invalid Customer ID")]
        [RequiredIfEmpty("Email")]
        //  [ValidateInquiryCriteria]
        public long? CustomerID { get; set; }


        [ValidateInquiryCriteria]
        [StringLength(25)]
        [EmailAddress(ErrorMessage ="Invalid Email")]
        [RequiredIfEmpty("CustomerID")]
        public string Email { get; set; }

     
    }
    
}
