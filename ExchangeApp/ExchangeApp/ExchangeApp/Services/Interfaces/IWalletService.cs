using ExchangeApp.Repository.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExchangeApp.API.Services.Interfaces
{
    public interface IWalletService
    {
        Task<IdentityResult> CreateWallet(Wallet wallet, string username);
        Wallet GetUserWallet(string username);
    }
}
