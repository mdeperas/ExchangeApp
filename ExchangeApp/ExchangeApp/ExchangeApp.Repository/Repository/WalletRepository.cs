﻿using ExchangeApp.Repository.Context;
using ExchangeApp.Repository.Models;
using ExchangeApp.Repository.Repository.Interfaces;
using System.Linq;
using System.Threading.Tasks;
using System.Data.Entity.Migrations;

namespace ExchangeApp.Repository.Repository
{
    public class WalletRepository : IWalletRepository
    {
        private readonly int masterWalletId = 1;

        private ExchangeAppContext _ctx;

        public WalletRepository(ExchangeAppContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<Wallet> FindWallet(int id)
        {
            return await _ctx.Wallets.FindAsync(id);
        }

        public async Task<ApplicationWallet> GetApplicationWallet()
        {
            return await _ctx.ApplicationWallets.FindAsync(masterWalletId);
        }

        public Wallet GetUserWallet(string username)
        {
            return _ctx.Wallets.FirstOrDefault(w => w.ExchangeAppUser.UserName.Equals(username));
        }

        public async Task<int> SaveWallet(Wallet wallet)
        {
            _ctx.Wallets.AddOrUpdate(w => w.Id, wallet);
            return await _ctx.SaveChangesAsync(); 
        }
    }
}