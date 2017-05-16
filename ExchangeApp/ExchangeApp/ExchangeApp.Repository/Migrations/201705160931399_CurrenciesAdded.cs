namespace ExchangeApp.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CurrenciesAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Currencies", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Currencies", "Unit", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Currencies", "Unit", c => c.String(nullable: false));
            DropColumn("dbo.Currencies", "Name");
        }
    }
}
