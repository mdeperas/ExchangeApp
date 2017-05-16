using ExchangeApp.API.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Routing;

namespace ExchangeApp.API.Controllers
{
    [RoutePrefix("api/currencies")]
    public class CurrencyController : ApiController
    {
        private ICurrencyService _currencyService;

        public CurrencyController(ICurrencyService currencyService)
        {
            _currencyService = currencyService;
        }

        [Authorize]
        [Route("")]
        public IHttpActionResult Get()
        {
            var temp = _currencyService.Get();

            return Ok(_currencyService.Get());
        }
    }
}
