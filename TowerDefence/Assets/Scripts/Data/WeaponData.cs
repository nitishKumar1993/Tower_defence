using UnityEngine;

namespace TowerDefence
{
    public enum WeaponType { LaserTower }

    [CreateAssetMenu(fileName = "WeaponData", menuName = "Game Data/Weapon Data")]
    public class WeaponData : ScriptableObject
    {
        [Header("General")]
        public string m_weaponName;
        public WeaponType m_weaponType;
        public GameObject m_prefab;

        [Header("Stats")]
        public int m_cost = 50;
        public float m_cooldown = 5f;
        public float m_range = 5f;
        public int m_damage = 10;

        [Header("Special")]
        public float m_duration = 0f;
    }
}