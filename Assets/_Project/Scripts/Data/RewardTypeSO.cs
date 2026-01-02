using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Vertigo.WOF.Data
{
    public enum RewardType
    {
        Bomb = 0,
        Cash = 1,
        Gold = 2,
        Chest = 3,
        Weapon = 4,
        Armor = 5,
        Point = 6,
        Consumable = 7
    }

    [CreateAssetMenu(fileName = "New Reward Type", menuName = "WOF/Reward Type")]
    public class RewardTypeSO : ScriptableObject
    {
        [Header("General Identity")]
        public RewardType type;
        public string displayName;

        [Header("Visuals")]
        public Sprite icon;
    }
}