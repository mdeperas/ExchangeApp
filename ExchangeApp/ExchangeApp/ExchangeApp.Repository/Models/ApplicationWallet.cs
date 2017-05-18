using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ExchangeApp.Repository.Models
{
    public class ApplicationWallet : Wallet
    {   
        [ForeignKey("Currency")]
        public int CurrencyId { get; set; }
        public Currency Currency { get; set; }
    }
}