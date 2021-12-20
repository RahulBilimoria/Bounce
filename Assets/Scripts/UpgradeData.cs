using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UpgradeSystem{
    [CreateAssetMenu(fileName = "UpgradeData", menuName = "Resources/CreateUpgradeData")]
    public class UpgradeData : ScriptableObject
    {
        public UpgradeItem[] upgradeItems;

        public void UpdateIndex(){
            upgradeItems[0].currentIndex = GameManager.manager.ballIndex;
            upgradeItems[1].currentIndex = GameManager.manager.pointsMultiIndex;
            upgradeItems[2].unlocked = GameManager.manager.comboUnlocked;
            upgradeItems[2].currentIndex = GameManager.manager.comboIndex;
            upgradeItems[3].unlocked = GameManager.manager.tapStrengthUnlocked;
            upgradeItems[3].currentIndex = GameManager.manager.tapStrengthIndex;
            upgradeItems[4].currentIndex = GameManager.manager.weaponTypeIndex;
            upgradeItems[5].currentIndex = GameManager.manager.weaponSpawnIndex;
        }
    }

    [System.Serializable]
    public class UpgradeItem {
        public string upgradeName;
        public int currentIndex;
        public bool unlocked;
        public int unlockCost;
        public UpgradeInfo[] UpgradeLevels;
    }

    [System.Serializable]
    public class UpgradeInfo{
        public int buyCost;
        public int value;
    }

    public class UnlockableItem {
        public string unlockName;
        public bool unlocked;
        public int unlockCost;
    }
}
