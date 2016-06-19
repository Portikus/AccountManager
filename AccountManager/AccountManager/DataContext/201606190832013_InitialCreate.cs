namespace AccountManager.DataContext
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Accounts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Earning_Id = c.Int(),
                        Spending_Id = c.Int(),
                        User_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Earnings", t => t.Earning_Id)
                .ForeignKey("dbo.Spendings", t => t.Spending_Id)
                .ForeignKey("dbo.Users", t => t.User_Id)
                .Index(t => t.Earning_Id)
                .Index(t => t.Spending_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.Earnings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Value = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Spendings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Value = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Accounts", "User_Id", "dbo.Users");
            DropForeignKey("dbo.Accounts", "Spending_Id", "dbo.Spendings");
            DropForeignKey("dbo.Accounts", "Earning_Id", "dbo.Earnings");
            DropIndex("dbo.Accounts", new[] { "User_Id" });
            DropIndex("dbo.Accounts", new[] { "Spending_Id" });
            DropIndex("dbo.Accounts", new[] { "Earning_Id" });
            DropTable("dbo.Users");
            DropTable("dbo.Spendings");
            DropTable("dbo.Earnings");
            DropTable("dbo.Accounts");
        }
    }
}
