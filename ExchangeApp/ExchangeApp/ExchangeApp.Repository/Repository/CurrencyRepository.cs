using ExchangeApp.Repository.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ExchangeApp.Repository.Models;
using ExchangeApp.Repository.Context;

namespace ExchangeApp.Repository.Repository
{
    public class CurrencyRepository : ICurrencyRepository
    {
        private ExchangeAppContext _ctx;
        public CurrencyRepository(ExchangeAppContext ctx)
        {
            _ctx = ctx;
        }
        public void Dispose()
        {
            _ctx.Dispose();
        }

        public List<Currency> GetCurrencies()
        {
            return _ctx.Currencies.ToList();
        }
    }
}