﻿namespace AccountManager.Entities
{
    public class Earning : Entity
    {
        public virtual decimal Value { get; set; }
        public virtual string Name { get; set; }
    }
}