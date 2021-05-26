using System;
namespace RPG.Interface
{
    public interface IFighter : IHealthy
    {

        public int Attack(IFighter toAttack);

        // can take in IFighter to do any disarm
        public int Defend(int incomingDamage);

    }
}
