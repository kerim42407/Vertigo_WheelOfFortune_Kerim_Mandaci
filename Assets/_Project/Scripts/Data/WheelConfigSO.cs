using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

namespace Vertigo.WOF.Data
{
    public enum WheelTier
    {
        Bronze = 0,
        Silver = 1,
        Gold = 2
    }

    [System.Serializable]
    public struct WheelSlice
    {
        public RewardTypeSO rewardData;
        public int amount;
    }

    [CreateAssetMenu(fileName = "New Wheel Config", menuName = "WOF/Wheel Config")]
    public class WheelConfigSO : ScriptableObject
    {
        [Header("Wheel Tier Settings")]
        public WheelTier tier;

        [Header("Wheel Slices")]
        public WheelSlice[] slices = new WheelSlice[8];

        private void OnValidate()
        {
            if (slices.Length != 8)
            {
                Debug.LogWarning($"[WheelConfigSO] '{name}' configuration must have exactly 8 slices. Current count: {slices.Length}");
            }

            ValidateEmptySlices();

            ValidateBombLogic();
        }

        private void ValidateEmptySlices()
        {
            if (slices == null) return;

            for (int i = 0; i < slices.Length; i++)
            {
                if (slices[i].rewardData == null)
                {
                    Debug.LogError($"[WheelConfigSO] Configuration error in '{name}': Slice {i} is empty. Please assign a Reward Asset.");
                }
            }
        }

        private void ValidateBombLogic()
        {
            if (slices == null || slices.Length == 0) return;

            int bombCount = 0;

            foreach (var slice in slices)
            {
                if (slice.rewardData != null && slice.rewardData.type == RewardType.Bomb)
                {
                    bombCount++;
                }
            }

            switch (tier)
            {
                case WheelTier.Bronze:
                    if (bombCount != 1)
                    {
                        Debug.LogError($"[WheelConfigSO] Configuration Error in '{name}': A Bronze tier wheel must contain exactly 1 bomb. Current: {bombCount}");
                    }
                    break;
                case WheelTier.Silver:
                case WheelTier.Gold:
                    if (bombCount > 0)
                    {
                        Debug.LogError($"[WheelConfigSO] Configuration Error in '{name}': A {tier} tier wheel must not contain any bombs. Current: {bombCount}");
                    }
                    break;
            }
        }
    }
}