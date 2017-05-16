using ExchangeApp.Repository.Context;
using ExchangeApp.Repository.Models;
using ExchangeApp.Repository.Repository.Interfaces;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace ExchangeApp.Repository.Repository
{
    public class AuthRepository : IAuthRepository
    {
        private ExchangeAppContext _ctx;
        private UserManager<ExchangeAppUser> _userManager;

        public AuthRepository(ExchangeAppContext ctx)
        {
            _ctx = ctx;
            _userManager = new UserManager<ExchangeAppUser>(new UserStore<ExchangeAppUser>(_ctx));
        }

        public async Task<ExchangeAppUser> FindUser(string username, string password)
        {
            return await _userManager.FindAsync(username, password);
        }

        public ExchangeAppUser FindUser(string username)
        {
            return _ctx.Users.FirstOrDefault(u => u.UserName.Equals(username));
        }

        public async Task<IdentityResult> RegisterUser(ExchangeAppUser exchangeAppUser, string password)
        {
            var user = _ctx.Users.FirstOrDefault(u => u.UserName.Equals(exchangeAppUser.UserName));

            if(user != null)
            {
                return IdentityResult.Failed($"Username {0} already exists.", exchangeAppUser.UserName);
            }

            return await _userManager.CreateAsync(exchangeAppUser, password);
        }
    }
}