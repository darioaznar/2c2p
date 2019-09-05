using _2C2P___Aznar.Converters;

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace _2C2P___Aznar.Models
{
    public class TransactionDto
    {
        public enum TransactionStatus
        {
            Success=0,
            Failed=1,
            Canceled=2
        }


        public enum TransactionCurrency
        {
            JPY,
            THB, 
            USD,
            SGD
        }

      
        [JsonProperty("id")]
        public long TransactionID { get; set; }

        [Required]
        [Column(TypeName ="DateTime")]
        [JsonConverter(typeof(DateFormatConverter),"dd/MM/yyyy HH:mm")]
        public DateTime Date { get; set; }
        
        public decimal Amount { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public TransactionCurrency Currency { get; set; }

        [Required]
        [JsonConverter(typeof(StringEnumConverter))]
        public TransactionStatus Status { get; set; }

       



    }
}
