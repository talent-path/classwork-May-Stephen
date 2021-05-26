using System;
using RPG.Abstracts;

namespace RPG.Weapons
{
    public class Fists : Weapon
    {
        public override int Damage { get; set; } = 1;
        public override int Durability { get; set; } = 500;

        public override int OnUse()
        {
            Durability--;
            return Durability;
        }

        public override int DamageCalculator()
        {
            return Damage;
        }

        public override string ToString()
        {
            return "Fists";
        }
    }
}
