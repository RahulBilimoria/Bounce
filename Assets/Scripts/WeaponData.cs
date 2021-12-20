using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WeaponSystem{
    [CreateAssetMenu(fileName = "WeaponData", menuName = "Resources/CreateWeaponData")]
    public class WeaponData : ScriptableObject {
        public Weapon[] weapons;
        public Special[] special;
        public PowerUp[] powerUp;
    }

    [System.Serializable]
    public class Weapon{
        public Sprite sprite;
        public AudioClip clip;
        public string weaponName;
        public int points;
        public int spawnChanceValue;
        public float size;
        public float xForce;
        public float yForce;
    }

    [System.Serializable]
    public class Special{
        public Sprite sprite;
        public AudioClip clip;
        public string name;
        public int points;
        public float size;
        public int spawnChance;
    }

    [System.Serializable]
    public class PowerUp{
        public Sprite sprite;
        public string name;
        public float size;
        public int spawnChance;
    }
}
