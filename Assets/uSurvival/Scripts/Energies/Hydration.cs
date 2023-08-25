using UnityEngine;

namespace uSurvival
{
    // inventory, attributes etc. can influence max
    public interface IHydrationBonus
    {
        int HydrationBonus(int baseHydration);
        int HydrationRecoveryBonus();
    }

    [DisallowMultipleComponent]
    public class Hydration : Energy
    {
        public int baseRecoveryPerTick = -1;
        public int baseHydration = 100;

        // cache components that give a bonus (attributes, inventory, etc.)
        // (assigned when needed. NOT in Awake because then prefab.max doesn't work)
        IHydrationBonus[] _bonusComponents;
        IHydrationBonus[] bonusComponents =>
            _bonusComponents ??= GetComponents<IHydrationBonus>();

        public override int max
        {
            get
            {
                // sum up manually. Linq.Sum() is HEAVY(!) on GC and performance (190 KB/call!)
                int bonus = 0;
                foreach (IHydrationBonus bonusComponent in bonusComponents)
                    bonus += bonusComponent.HydrationBonus(baseHydration);
                return baseHydration + bonus;
            }
        }

        public override int recoveryPerTick
        {
            get
            {
                // sum up manually. Linq.Sum() is HEAVY(!) on GC and performance (190 KB/call!)
                int bonus = 0;
                foreach (IHydrationBonus bonusComponent in bonusComponents)
                    bonus += bonusComponent.HydrationRecoveryBonus();
                return baseRecoveryPerTick + bonus;
            }
        }
    }
}