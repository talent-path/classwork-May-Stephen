using System;
using RPG.Abstracts;


namespace RPG.ArmorType
{
    public class Helmet : Clothing
    {
        public override int Durability { get; set; } = 500;

        public override int ReduceDamage(int damage)
        {
            damage -= 1;
            return damage;
        }
    }
}
