using System.Collections.Generic;

namespace AccountManager.Entities
{
    public class Account : Entity
    {

        public virtual string Name { get; set; }

        public virtual List<Spending> Spendings { get; set; }

        public virtual List<Earning> Earnings { get; set; }

        public virtual User User { get; set; }
    }
}
