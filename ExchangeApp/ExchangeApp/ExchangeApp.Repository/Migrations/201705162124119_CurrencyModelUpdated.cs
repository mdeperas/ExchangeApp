namespace ExchangeApp.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CurrencyModelUpdated : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Currencies", "Code", c => c.String(nullable: false));
            DropColumn("dbo.Currencies", "ShortCode");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Currencies", "ShortCode", c => c.String(nullable: false));
            DropColumn("dbo.Currencies", "Code");
        }
    }
}
