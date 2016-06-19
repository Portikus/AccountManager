namespace AccountManager.Entities
{
    public class Spending : Entity
    {
        public virtual decimal Value { get; set; }
        public virtual string Name { get; set; }
    }
}