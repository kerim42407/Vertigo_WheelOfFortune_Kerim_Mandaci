using UnityEngine;
using Vertigo.WOF.Data;

namespace Vertigo.WOF.Managers
{
    public class ZoneManager : MonoBehaviour
    {
        [Header("Wheel Configurations")]
        [SerializeField] private WheelConfigSO bronzeConfig;
        [SerializeField] private WheelConfigSO silverConfig;
        [SerializeField] private WheelConfigSO goldConfig;

        [Header("Debug")]
        [SerializeField] private int currentZone = 1;

        public static ZoneManager Instance { get; private set; }

        private void Awake()
        {
            if (Instance == null && Instance != this)
            {
                Instance = this;
            }
            else
            {
                Destroy(gameObject);
            }
        }

        public int CurrentZone => currentZone;

        public void MoveToNextZone()
        {
            currentZone++;
            Debug.Log($"[ZoneManager] Moved to Zone: {currentZone}");
        }

        public WheelConfigSO GetCurrentWheelConfig()
        {
            if (currentZone % 30 == 0)
            {
                return goldConfig;
            }

            if (currentZone % 5 == 0)
            {
                return silverConfig;
            }

            return bronzeConfig;
        }

        public int GetCurrentMultiplier()
        {
            return currentZone;
        }
    }
}