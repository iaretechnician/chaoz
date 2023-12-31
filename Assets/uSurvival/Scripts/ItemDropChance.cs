// Defines the drop chance of an item for monster loot generation.
using System;
using UnityEngine;

namespace uSurvival
{
    [Serializable]
    public class ItemDropChance
    {
        public ItemDrop drop;
        [Range(0,1)] public float probability;
    }
}