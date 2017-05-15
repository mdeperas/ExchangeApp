using ExchangeApp.API.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExchangeApp.API.Services.Interfaces
{
    interface IExchangeAppUserService : IDisposable
    {
        ExchangeAppUserModel GetUser(string username);
        Task<IdentityResult> Register(ExchangeAppUserModel exchangeAppUserModel);
    }
}
