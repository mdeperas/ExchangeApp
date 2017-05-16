using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ExchangeApp.Repository.Models
{
    public class Currency
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Code { get; set; }
        [Required]
        public int Unit { get; set; }
        [Required]
        public string Name { get; set; }
    }
}