using UnityEngine;

namespace uSurvival
{
    // inventory, attributes etc. can influence max health
    public interface IHealthBonus
    {
        int HealthBonus(int baseHealth);
        int HealthRecoveryBonus();
    }

    [DisallowMultipleComponent]
    public class Health : Energy
    {
        public int baseRecoveryPerTick = 0;
        public int baseHealth = 100;

        // cache components that give a bonus (attributes, inventory, etc.)
        // (assigned when needed. NOT in Awake because then prefab.max doesn't work)
        IHealthBonus[] _bonusComponents;
        IHealthBonus[] bonusComponents =>
            _bonusComponents ??= GetComponents<IHealthBonus>();

        public override int max
        {
            get
            {
                // sum up manually. Linq.Sum() is HEAVY(!) on GC and performance (190 KB/call!)
                int bonus = 0;
                foreach (IHealthBonus bonusComponent in bonusComponents)
                    bonus += bonusComponent.HealthBonus(baseHealth);
                return baseHealth + bonus;
            }
        }

        public override int recoveryPerTick
        {
            get
            {
                // sum up manually. Linq.Sum() is HEAVY(!) on GC and performance (190 KB/call!)
                int bonus = 0;
                foreach (IHealthBonus bonusComponent in bonusComponents)
                    bonus += bonusComponent.HealthRecoveryBonus();
                return baseRecoveryPerTick + bonus;
            }
        }
    }
}