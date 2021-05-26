using System;
using RPG.Interface;

namespace RPG.Abstracts
{
    public abstract class Clothing : IArmor
    {
        public abstract int Durability { get; set; }

        public abstract int ReduceDamage(int damage);
        
    }
}
