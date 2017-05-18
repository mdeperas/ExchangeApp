namespace ExchangeApp.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserModelUpdated : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Wallets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ExchangeAppUserId = c.String(maxLength: 128),
                        CurrencyId = c.Int(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Currencies", t => t.CurrencyId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.ExchangeAppUserId)
                .Index(t => t.ExchangeAppUserId)
                .Index(t => t.CurrencyId);
            
            CreateTable(
                "dbo.Resources",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CurrencyId = c.Int(nullable: false),
                        WalletId = c.Int(nullable: false),
                        Amount = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Currencies", t => t.CurrencyId, cascadeDelete: true)
                .ForeignKey("dbo.Wallets", t => t.WalletId, cascadeDelete: true)
                .Index(t => t.CurrencyId)
                .Index(t => t.WalletId);
            
            DropColumn("dbo.AspNetUsers", "Name");
            DropColumn("dbo.AspNetUsers", "Surname");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "Surname", c => c.String());
            AddColumn("dbo.AspNetUsers", "Name", c => c.String());
            DropForeignKey("dbo.Resources", "WalletId", "dbo.Wallets");
            DropForeignKey("dbo.Wallets", "ExchangeAppUserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Resources", "CurrencyId", "dbo.Currencies");
            DropForeignKey("dbo.Wallets", "CurrencyId", "dbo.Currencies");
            DropIndex("dbo.Resources", new[] { "WalletId" });
            DropIndex("dbo.Resources", new[] { "CurrencyId" });
            DropIndex("dbo.Wallets", new[] { "CurrencyId" });
            DropIndex("dbo.Wallets", new[] { "ExchangeAppUserId" });
            DropTable("dbo.Resources");
            DropTable("dbo.Wallets");
        }
    }
}
