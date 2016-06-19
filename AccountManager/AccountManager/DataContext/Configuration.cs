using AccountManager.Entities;

namespace AccountManager.DataContext
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<FinanceDatabase>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"DataContext";
        }

        protected override void Seed(FinanceDatabase context)
        {
            context.Accounts.RemoveRange(context.Accounts);
            context.Earnings.RemoveRange(context.Earnings);
            context.Spendings.RemoveRange(context.Spendings);
            context.Users.RemoveRange(context.Users);
            context.SaveChanges();

            context.Users.Add(new User {Name = "Testuser"});
            context.Accounts.Add(new Account {Name = "Konto1"});
            context.SaveChanges();
            context.Accounts.First().User = context.Users.First();
            context.SaveChanges();
        }
    }
}
