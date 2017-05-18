namespace ExchangeApp.Repository.Migrations
{
    using Context;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ExchangeAppContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(ExchangeAppContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            SeedRoles(context);
            SeedUsers(context);
            SeedCurrencies(context);
            SeedApplicationWallet(context);
            SeedResources(context);
        }

        private void SeedRoles(ExchangeAppContext ctx)
        {
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(ctx));

            if (!roleManager.RoleExists("Admin"))
            {
                var role = new IdentityRole();
                role.Name = "Admin";
                roleManager.Create(role);
            }
        }

        private void SeedUsers(ExchangeAppContext ctx)
        {
            var store = new UserStore<ExchangeAppUser>(ctx);
            var manager = new UserManager<ExchangeAppUser>(store);
            if (!ctx.Users.Any(u => u.UserName == "Admin"))
            {
                var user = new ExchangeAppUser { UserName = "Admin" };
                var adminResult = manager.Create(user, "12345678");

                if (adminResult.Succeeded)
                {
                    manager.AddToRole(user.Id, "Admin");
                }
            }
        }

        private void SeedCurrencies(ExchangeAppContext ctx)
        {
            ctx.Currencies.AddOrUpdate(
                new Currency()
                {
                    Id = 1,
                    Code = "PLN",
                    Name = "Polish zloty",
                    Unit = 1
                },
                new Currency()
                {
                    Id = 2,
                    Code = "USD",
                    Name = "US Dollar",
                    Unit = 1
                },
                new Currency()
                {
                    Id = 3,
                    Code = "EUR",
                    Name = "Euro",
                    Unit = 1
                },
                new Currency()
                {
                    Id = 4,
                    Code = "CHF",
                    Name = "Swiss Franc",
                    Unit = 1
                },
                new Currency()
                {
                    Id = 5,
                    Code = "RUB",
                    Name = "Russian ruble",
                    Unit = 100
                },
                new Currency()
                {
                    Id = 6,
                    Code = "CZK",
                    Name = "Czech koruna",
                    Unit = 100
                },
                new Currency()
                {
                    Id = 7,
                    Code = "GBP",
                    Name = "Pound sterling",
                    Unit = 1
                }
                );
            ctx.SaveChanges();
        }

        private void SeedApplicationWallet(ExchangeAppContext ctx)
        {
            ctx.ApplicationWallets.AddOrUpdate(
                new ApplicationWallet()
                {
                    Id = 1,
                    CurrencyId = 1
                });
            ctx.SaveChanges();
        }

        private void SeedResources(ExchangeAppContext ctx)
        {
            ctx.Resources.AddOrUpdate(
                new Resource()
                {
                    Id = 1,
                    WalletId = 1,
                    Amount = 999999,
                    CurrencyId = 1
                },
                new Resource()
                {
                    Id = 2,
                    WalletId = 1,
                    Amount = 999999,
                    CurrencyId = 2
                },
                new Resource()
                {
                    Id = 3,
                    WalletId = 1,
                    Amount = 999999,
                    CurrencyId = 3
                },
                new Resource()
                {
                    Id = 4,
                    WalletId = 1,
                    Amount = 999999,
                    CurrencyId = 4
                },
                new Resource()
                {
                    Id = 5,
                    WalletId = 1,
                    Amount = 999999,
                    CurrencyId = 5
                },
                new Resource()
                {
                    Id = 6,
                    WalletId = 1,
                    Amount = 999999,
                    CurrencyId = 6
                },
                new Resource()
                {
                    Id = 7,
                    WalletId = 1,
                    Amount = 999999,
                    CurrencyId = 7
                });
            ctx.SaveChanges();
        }
    }
}
