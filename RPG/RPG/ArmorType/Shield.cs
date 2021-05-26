using System;
using RPG.Abstracts;
namespace RPG.ArmorType
{
    public class Shield : Clothing
    {

        public override int Durability { get; set; } = 150;

        public override int ReduceDamage(int damage)
        {
            if (Durability == 0)
            {
                return damage;
            }
            else
            {
                System.Random random = new System.Random();
                int DamageDealt = random.Next() % 2;
                if (DamageDealt == 1)
                {
                    damage = 0;
                }

                return damage;
            }


        }
        public override string ToString()
        {
            return "Shield";
        }

    }
}
