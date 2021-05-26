using System;
using RPG.Abstracts;

namespace RPG.Weapons
{
    public class Crossbow : Weapon
    {
       

        public override int Damage { get; set; }
        public override int Durability { get; set; }

        public override int OnUse()
        {
            return Durability;
        }

        public override int DamageCalculator()
        {
            System.Random random = new System.Random();
            int DamageDealt = random.Next() %2;
            if (DamageDealt == 1)
            {
                DamageDealt = 0;
            }
            else
            {
                DamageDealt = 20;
            }
            return DamageDealt;
        }
    }
}
