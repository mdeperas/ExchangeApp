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
    public class Wallet
    {
        public Wallet()
        {
            Resources = new List<Resource>();
        }

        [Key]
        public int Id { get; set; }

        [JsonIgnore]
        [XmlIgnore]
        [ForeignKey("ExchangeAppUser")]
        public string ExchangeAppUserId { get; set; }

        [JsonIgnore]
        [XmlIgnore]
        public virtual ExchangeAppUser ExchangeAppUser { get; set; }

        [Required]
        public virtual ICollection<Resource> Resources { get; set; }
    }
}