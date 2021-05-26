using System;
using RPG.Abstracts;
using RPG.Interface;
using RPG.Weapons;
using RPG.ArmorType;

namespace RPG.Classes
{
    public class Brute : Fighter
    {

        public override int TotalHealth { get; set; } = 150;
        public override Weapon weapon { get; set; }
        public override Clothing armor { get; set; }

        public Brute() { }

        public override int Attack(IFighter toAttack)
        {
           
            return toAttack.Defend(weapon.DamageCalculator() + 1);
        }

        public override int Defend(int incomingDamage)
        {
            return TotalHealth -= incomingDamage;
        }

        


    }
}
