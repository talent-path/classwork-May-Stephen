using System;
using RPG.Interface;

namespace RPG.Abstracts
{
    public abstract class Weapon : IWeapon
    {
        public abstract int Damage { get; set; }
        public abstract int Durability { get; set; }

        public abstract int OnUse();

        public abstract int DamageCalculator();

    }
}
