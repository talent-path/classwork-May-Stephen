using System;
using RPG.Interface;

namespace RPG.Abstracts
{
    public abstract class Fighter : IFighter
    {
        
        public abstract int TotalHealth { get; set; }
        public abstract Weapon weapon { get; set; }
        public abstract Clothing armor { get; set; }

        public Fighter() { }

        public Fighter(Weapon weapon, Clothing armor)
        {
            this.weapon = weapon;
            this.armor = armor;
        }

        public abstract int Attack(IFighter toAttack);


        public abstract int Defend(int incomingDamage);
        
        
    }
}
