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
                        User_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.User_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.Earnings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Value = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Name = c.String(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                        SenderAccount_Id = c.Int(),
                        Account_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Accounts", t => t.SenderAccount_Id)
                .ForeignKey("dbo.Accounts", t => t.Account_Id)
                .Index(t => t.SenderAccount_Id)
                .Index(t => t.Account_Id);
            
            CreateTable(
                "dbo.Spendings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Value = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Name = c.String(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                        RecivingAccount_Id = c.Int(),
                        Account_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Accounts", t => t.RecivingAccount_Id)
                .ForeignKey("dbo.Accounts", t => t.Account_Id)
                .Index(t => t.RecivingAccount_Id)
                .Index(t => t.Account_Id);
            
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
            DropForeignKey("dbo.Spendings", "Account_Id", "dbo.Accounts");
            DropForeignKey("dbo.Spendings", "RecivingAccount_Id", "dbo.Accounts");
            DropForeignKey("dbo.Earnings", "Account_Id", "dbo.Accounts");
            DropForeignKey("dbo.Earnings", "SenderAccount_Id", "dbo.Accounts");
            DropIndex("dbo.Spendings", new[] { "Account_Id" });
            DropIndex("dbo.Spendings", new[] { "RecivingAccount_Id" });
            DropIndex("dbo.Earnings", new[] { "Account_Id" });
            DropIndex("dbo.Earnings", new[] { "SenderAccount_Id" });
            DropIndex("dbo.Accounts", new[] { "User_Id" });
            DropTable("dbo.Users");
            DropTable("dbo.Spendings");
            DropTable("dbo.Earnings");
            DropTable("dbo.Accounts");
        }
    }
}
