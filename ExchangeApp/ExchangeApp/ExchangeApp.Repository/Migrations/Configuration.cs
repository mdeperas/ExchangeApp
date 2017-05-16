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

    internal sealed class Configuration : DbMigrationsConfiguration<ExchangeApp.Repository.Context.ExchangeAppContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(ExchangeApp.Repository.Context.ExchangeAppContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            SeedRoles(context);
            SeedUsers(context);
            SeedCurrencies(context);
        }

        private void SeedRoles(ExchangeAppContext ctx)
        {
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(ctx));

            if(!roleManager.RoleExists("Admin"))
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
                var user = new ExchangeAppUser { UserName = "Admin", Name = "Kamil", Surname = "Kamilianski" };
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
                    ShortCode = "PLN",
                    Name = "Polish zloty",
                    Unit = 1
                },
                new Currency()
                {
                    Id = 2,
                    ShortCode = "USD",
                    Name = "US Dollar",
                    Unit = 1
                },
                new Currency()
                {
                    Id = 3,
                    ShortCode = "EUR",
                    Name = "Euro",
                    Unit = 1
                },
                new Currency()
                {
                    Id = 4,
                    ShortCode = "CHF",
                    Name = "Swiss Franc",
                    Unit = 1
                },
                new Currency()
                {
                    Id = 5,
                    ShortCode = "RUB",
                    Name = "Russian ruble",
                    Unit = 100
                },
                new Currency()
                {
                    Id = 6,
                    ShortCode = "CZK",
                    Name = "Czech koruna",
                    Unit = 100
                },
                new Currency()
                {
                    Id = 7,
                    ShortCode = "GBP",
                    Name = "Pound sterling",
                    Unit = 1
                }
                );
            ctx.SaveChanges();
        }
    }
}
