using ExchangeApp.API.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ExchangeApp.API.Models;
using Microsoft.AspNet.Identity;
using System.Threading.Tasks;
using ExchangeApp.Repository.Repository;
using ExchangeApp.Repository.Repository.Interfaces;
using ExchangeApp.Repository.Models;

namespace ExchangeApp.API.Services
{
    public class ExchangeAppUserService : IExchangeAppUserService
    {
        private IAuthRepository _authRepository; 

        public ExchangeAppUserService(IAuthRepository authRepository)
        {
            _authRepository = authRepository;
        }

        public ExchangeAppUserModel GetUser(string username)
        {
            ExchangeAppUser exchangeAppUser = _authRepository.FindUser(username);

            if(exchangeAppUser == null)
            {
                return null;
            }

            return new ExchangeAppUserModel()
            {
                Name = exchangeAppUser.Name,
                Surname = exchangeAppUser.Surname,
                UserName = username
            };
        }

        public async Task<IdentityResult> Register(ExchangeAppUserModel exchangeAppUserModel)
        {
            ExchangeAppUser exchangeAppUser = new ExchangeAppUser()
            {
                Name = exchangeAppUserModel.Name,
                Surname = exchangeAppUserModel.Surname,
                UserName = exchangeAppUserModel.UserName
            };

            return await _authRepository.RegisterUser(exchangeAppUser, exchangeAppUserModel.Password);
        }
    }
}