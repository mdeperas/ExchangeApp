using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace ExchangeApp.Repository.Models
{
    public class Resource
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Currency")]
        public int CurrencyId { get; set; }
        [ForeignKey("Wallet")]
        public int WalletId { get; set; }

        [Required]
        public int Amount { get; set; }

        [JsonIgnore]
        [XmlIgnore]
        public virtual Wallet Wallet { get; set; }
        public virtual Currency Currency { get; set; }
    }
}