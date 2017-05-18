using ExchangeApp.API.Services.Interfaces;
using ExchangeApp.Repository.Models;
using ExchangeApp.Repository.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace ExchangeApp.API.Services
{
    public class CurrencyService : ICurrencyService
    {
        private ICurrencyRepository _currencyRepository;

        public CurrencyService(ICurrencyRepository currencyRepository)
        {
            _currencyRepository = currencyRepository;
        }

        public List<Currency> Get()
        {
            return _currencyRepository.GetCurrencies();
        }
    }
}