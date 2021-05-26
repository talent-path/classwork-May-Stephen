using System;
using RPG.Abstracts;
using RPG.Interface;

namespace RPG.Classes
{
    public class Troll : Fighter
    {
        public override int TotalHealth { get; set; } = 100;
        public override Weapon weapon { get; set; }
        public override Clothing armor { get; set; }

        public Troll() { }

        public override int Attack(IFighter toAttack)
        {

            return toAttack.Defend(weapon.DamageCalculator());
        }

        public override int Defend(int incomingDamage)
        {
           
            return TotalHealth -= incomingDamage + 1;
        }
    }
}
