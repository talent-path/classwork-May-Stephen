using System;
using RPG.Abstracts;
using RPG.Interface;

namespace RPG.Classes
{
    public class Thief : Fighter
    {
        public override int TotalHealth { get; set; } = 100;
        public override Weapon weapon { get; set; }
        public override Clothing armor { get; set; }

        public Thief() { }

        public override int Attack(IFighter toAttack)
        {
            Random random = new Random();
            int chance = random.Next() % 4;
            if (chance == 4)
            {
                toAttack.Damage = 0;
                Console.WriteLine("You disarmed the monster!");
            }
            return toAttack.Defend(weapon.DamageCalculator());
        }

        public override int Defend(int incomingDamage)
        {
            return TotalHealth -= incomingDamage;
        }

     
    }
}
