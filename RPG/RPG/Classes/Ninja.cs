using System;
using RPG.Abstracts;
using RPG.Interface;

namespace RPG.Classes
{
    public class Ninja : Fighter
    {
        public override int TotalHealth { get; set; } = 100;
        public override Weapon weapon { get; set; }
        public override Clothing armor { get; set; }

        public Ninja() { }

        public override int Attack(IFighter toAttack)
        {

            return toAttack.Defend(weapon.DamageCalculator());
        }

        public override int Defend(int incomingDamage)
        {
            Random random = new Random();
            int chance = random.Next() % 2;

            if( chance == 1)
            {
                Console.WriteLine("Ninja succesfully dodged the attack!");
                return TotalHealth;
            }

            return TotalHealth -= incomingDamage;
        }

        public override string ToString()
        {
            return "Ninja";
        }

    }
}
