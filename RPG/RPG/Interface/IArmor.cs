using System;
namespace RPG.Interface
{
    public interface IArmor
    {
        public int ReduceDamage(int damage);
        int Durability { get; set; }
    }
}
