namespace ATM_ASP.NET_MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ApplyPropDateAndTypeToTransactions : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Transactions", "TransactionDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Transactions", "TransactionType", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Transactions", "TransactionType");
            DropColumn("dbo.Transactions", "TransactionDate");
        }
    }
}
