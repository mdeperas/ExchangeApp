using ExchangeApp.Repository.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExchangeApp.Repository.Repository.Interfaces
{
    public interface ICurrencyRepository
    {
        List<Currency> GetCurrencies();
    }
}
