using System;
namespace RPG.Interface
{
    public interface IWeapon
    {
        int Damage { get; set; }
        int Durability { get; set; }
    }
}
