using ExchangeApp.API.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ExchangeApp.Repository.Models;
using Microsoft.AspNet.Identity;
using System.Threading.Tasks;
using ExchangeApp.Repository.Repository.Interfaces;

namespace ExchangeApp.API.Services
{
    public class WalletService : IWalletService
    {
        private IWalletRepository _walletRepository;
        private IAuthRepository _authRepository;

        public WalletService(IWalletRepository walletRepository, IAuthRepository authRepository)
        {
            _walletRepository = walletRepository;
            _authRepository = authRepository;
        }

        public async Task<IdentityResult> CreateWallet(Wallet wallet, string username)
        {
            var user = _authRepository.FindUser(username);

            if(user == null)
            {
                return IdentityResult.Failed("There is no such user.");
            }

            wallet.ExchangeAppUserId = user.Id;

            foreach(Resource resource in wallet.Resources)
            {
                resource.Currency = null;
            }

            var walletHasBeenSaved = await this._walletRepository.SaveWallet(wallet);
            if(walletHasBeenSaved > 0)
            {
                return IdentityResult.Success;
            }

            return IdentityResult.Failed("Wallet changes has not been saved");
        }

        public Wallet GetUserWallet(string username)
        {
            return _walletRepository.GetUserWallet(username);
        }
    }
}