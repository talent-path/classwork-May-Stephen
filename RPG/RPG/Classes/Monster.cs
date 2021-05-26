using System;
using RPG.Abstracts;
using RPG.Interface;
using RPG.Weapons;
using RPG.ArmorType;

namespace RPG.Classes
{
    public class Monster : Fighter
    {
        public Monster()
        {
            this.weapon = new Sword();
            this.armor = new Helmet();
            this.TotalHealth = 50;
        }

        public override int TotalHealth { get ; set; }
        public override Weapon weapon { get ; set ; }
        public override Clothing armor { get ; set ; }

        public override int Attack(IFighter toAttack)
        {

            return toAttack.Defend(weapon.DamageCalculator());
        }

        public override int Defend(int incomingDamage)
        {

            return TotalHealth -= incomingDamage;
        }
    }
}
