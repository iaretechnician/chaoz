using UnityEngine;

namespace uSurvival
{
    // inventory, attributes etc. can influence max
    public interface INutritionBonus
    {
        int NutritionBonus(int baseNutrition);
        int NutritionRecoveryBonus();
    }

    [DisallowMultipleComponent]
    public class Nutrition : Energy
    {
        public int baseRecoveryPerTick = -1;
        public int baseNutrition = 100;

        // cache components that give a bonus (attributes, inventory, etc.)
        // (assigned when needed. NOT in Awake because then prefab.max doesn't work)
        INutritionBonus[] _bonusComponents;
        INutritionBonus[] bonusComponents =>
            _bonusComponents ??= GetComponents<INutritionBonus>();

        public override int max
        {
            get
            {
                // sum up manually. Linq.Sum() is HEAVY(!) on GC and performance (190 KB/call!)
                int bonus = 0;
                foreach (INutritionBonus bonusComponent in bonusComponents)
                    bonus += bonusComponent.NutritionBonus(baseNutrition);
                return baseNutrition + bonus;
            }
        }

        public override int recoveryPerTick
        {
            get
            {
                // sum up manually. Linq.Sum() is HEAVY(!) on GC and performance (190 KB/call!)
                int bonus = 0;
                foreach (INutritionBonus bonusComponent in bonusComponents)
                    bonus += bonusComponent.NutritionRecoveryBonus();
                return baseRecoveryPerTick + bonus;
            }
        }
    }
}