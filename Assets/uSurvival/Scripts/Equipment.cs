using UnityEngine;

namespace uSurvival
{
    [DisallowMultipleComponent]
    [RequireComponent(typeof(Health))]
    [RequireComponent(typeof(Inventory))]
    public abstract class Equipment : ItemContainer, IHealthBonus, IHydrationBonus, INutritionBonus, ICombatBonus
    {
        // Used components. Assign in Inspector. Easier than GetComponent caching.
        public Health health;
        public Inventory inventory;

        // energy boni
        public int HealthBonus(int baseHealth)
        {
            // sum up manually. Linq.Sum() is HEAVY(!) on GC and performance (190 KB/call!)
            int bonus = 0;
            foreach (ItemSlot slot in slots)
                if (slot.amount > 0 && slot.item.CheckDurability())
                    bonus += ((EquipmentItem)slot.item.data).healthBonus;
            return bonus;
        }
        public int HealthRecoveryBonus() => 0;
        public int HydrationBonus(int baseHydration)
        {
            // sum up manually. Linq.Sum() is HEAVY(!) on GC and performance (190 KB/call!)
            int bonus = 0;
            foreach (ItemSlot slot in slots)
                if (slot.amount > 0 && slot.item.CheckDurability())
                    bonus += ((EquipmentItem)slot.item.data).hydrationBonus;
            return bonus;
        }
        public int HydrationRecoveryBonus() => 0;
        public int NutritionBonus(int baseNutrition)
        {
            // sum up manually. Linq.Sum() is HEAVY(!) on GC and performance (190 KB/call!)
            int bonus = 0;
            foreach (ItemSlot slot in slots)
                if (slot.amount > 0 && slot.item.CheckDurability())
                    bonus += ((EquipmentItem)slot.item.data).nutritionBonus;
            return bonus;
        }
        public int NutritionRecoveryBonus() => 0;

        // combat boni
        public int DamageBonus()
        {
            // sum up manually. Linq.Sum() is HEAVY(!) on GC and performance (190 KB/call!)
            int bonus = 0;
            foreach (ItemSlot slot in slots)
                if (slot.amount > 0 && slot.item.CheckDurability())
                    bonus += ((EquipmentItem)slot.item.data).damageBonus;
            return bonus;
        }
        public int DefenseBonus()
        {
            // sum up manually. Linq.Sum() is HEAVY(!) on GC and performance (190 KB/call!)
            int bonus = 0;
            foreach (ItemSlot slot in slots)
                if (slot.amount > 0 && slot.item.CheckDurability())
                    bonus += ((EquipmentItem)slot.item.data).defenseBonus;
            return bonus;
        }
    }
}