using ExchangeApp.Repository.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ExchangeApp.Repository.Context
{
    public class ExchangeAppContext : IdentityDbContext<ExchangeAppUser>
    {
        public ExchangeAppContext() : base("ExchangeAppContext")
        {
        }

        public ExchangeAppContext(string nameOrConnectionString) : base(nameOrConnectionString)
        {
        }

        public DbSet<ExchangeAppUser> ExchangeAppUsers { get; set; }
    }
}