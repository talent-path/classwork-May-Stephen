using System;
using RPG.Interface;
using RPG.Abstracts;
namespace RPG.Weapons
{
    public class Sword : Weapon
    {

        public override int Damage { get; set; } = 10;
        public override int Durability { get; set; } = 80;

        public override int DamageCalculator()
        {
            System.Random random = new System.Random();
            int DamageDealt = random.Next()%6 + 5;
            return DamageDealt;
        }

        public override int OnUse()
        {
            Durability--;
            return Durability;
        }
    }
}
