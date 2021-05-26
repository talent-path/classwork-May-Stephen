using System;
using RPG.Abstracts;
namespace RPG.ArmorType

{
    public class Shirt : Clothing
    {

        public override int Durability { get; set; } = 75;

        public override int ReduceDamage(int damage)
        {
            damage--;
            return damage;
        }
    }
}
