namespace AccountManager.Entities
{
    public class Account : Entity
    {
        public virtual User User { get; set; }

        public virtual string Name { get; set; }

        public virtual Spending Spending { get; set; }

        public virtual Earning Earning { get; set; }
    }
}
