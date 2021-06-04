using System;
namespace RPG.Interface
{
    public interface IFighter : IHealthy, IWeapon
    {

        public int Attack(IFighter toAttack);

        // can take in IFighter to do any disarm
        public int Defend(int incomingDamage);

        public int row { get; set; }
        public int col { get; set; }

    }
}
