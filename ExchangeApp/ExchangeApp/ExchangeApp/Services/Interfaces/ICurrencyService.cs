using ExchangeApp.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace ExchangeApp.API.Services.Interfaces
{
    public interface ICurrencyService : IDisposable
    {
        List<Currency> Get();
    }
}
