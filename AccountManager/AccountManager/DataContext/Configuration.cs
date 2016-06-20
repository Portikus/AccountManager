using System.Collections.Generic;
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

            context.Users.Add(new User { Name = "Testuser" });
            context.Users.Add(new User { Name = "Testuser2" });

            context.Accounts.Add(new Account { Name = "Konto1" });
            context.Accounts.Add(new Account { Name = "Konto2" });

            context.Earnings.Add(new Earning { Name = "Gehalt", Value = 1000 });
            context.Earnings.Add(new Earning { Name = "Miete", Value = 300 });
            context.Earnings.Add(new Earning { Name = "Gehalt", Value = 500 });
            context.Earnings.Add(new Earning { Name = "Gehalt2", Value = 400 });

            context.Spendings.Add(new Spending { Name = "Haushalt", Value = 500 });
            context.Spendings.Add(new Spending { Name = "Tanken", Value = 150 });
            context.Spendings.Add(new Spending { Name = "Auto", Value = 200 });
            context.Spendings.Add(new Spending { Name = "Kosmetik", Value = 75.10m });

            context.SaveChanges();
            var spendings = context.Spendings.ToList();
            var earnings = context.Earnings.ToList();
            var accounts = context.Accounts.ToList();

            accounts[0].User = context.Users.First();
            accounts[0].Spendings = new List<Spending> { spendings[0], spendings[1] };
            accounts[0].Earnings = new List<Earning> { earnings[0], earnings[1] };

            accounts[1].User = context.Users.ToList()[1];
            accounts[1].Spendings = new List<Spending> { spendings[2], spendings[3] };
            accounts[1].Earnings = new List<Earning> { earnings[2], earnings[3] };

            context.SaveChanges();
        }
    }
}
