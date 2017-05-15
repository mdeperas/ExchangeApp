using ExchangeApp.API.Services.Interfaces;
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

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public IHttpActionResult Get()
        {
            throw new NotImplementedException();
        }
    }
}