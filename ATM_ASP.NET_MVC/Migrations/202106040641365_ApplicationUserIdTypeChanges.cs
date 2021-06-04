namespace ATM_ASP.NET_MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ApplicationUserIdTypeChanges : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.CheckingAccounts", new[] { "User_Id" });
            DropColumn("dbo.CheckingAccounts", "ApplicationUserId");
            RenameColumn(table: "dbo.CheckingAccounts", name: "User_Id", newName: "ApplicationUserId");
            AlterColumn("dbo.CheckingAccounts", "ApplicationUserId", c => c.String(maxLength: 128));
            CreateIndex("dbo.CheckingAccounts", "ApplicationUserId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.CheckingAccounts", new[] { "ApplicationUserId" });
            AlterColumn("dbo.CheckingAccounts", "ApplicationUserId", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.CheckingAccounts", name: "ApplicationUserId", newName: "User_Id");
            AddColumn("dbo.CheckingAccounts", "ApplicationUserId", c => c.Int(nullable: false));
            CreateIndex("dbo.CheckingAccounts", "User_Id");
        }
    }
}
