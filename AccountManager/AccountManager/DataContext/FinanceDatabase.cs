using System.Data.Entity;
using AccountManager.Entities;

namespace AccountManager.DataContext
{
    public class FinanceDatabase : DbContext
    {
        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Earning> Earnings { get; set; }
        public virtual DbSet<Spending> Spendings { get; set; }

        public FinanceDatabase() : base("DefaultConnection")
        {
            
        }
    }
}
