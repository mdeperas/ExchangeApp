using ExchangeApp.Repository.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExchangeApp.Repository.Repository.Interfaces
{
    public interface IAuthRepository
    {
        Task<ExchangeAppUser> FindUser(string username, string password);
        ExchangeAppUser FindUser(string username);
        Task<IdentityResult> RegisterUser(ExchangeAppUser exchangeAppUser, string password);
    }
}
