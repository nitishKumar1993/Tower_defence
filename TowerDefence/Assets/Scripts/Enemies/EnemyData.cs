using UnityEngine;

namespace TowerDefence
{
    [CreateAssetMenu(fileName = "EnemyData", menuName = "Game Data/Enemy Data")]
    public class EnemyData : ScriptableObject
    {
        public string m_name = "";

        [Header("Stats")]
        public float m_moveSpeed = 2f;
        public int m_maxHealth = 5;
        public int m_reward = 10;
        public int m_damageToTower = 1;

        [Header("Appearance")]
        public GameObject m_prefab;

        [Header("Path")]
        [TagSelector]
        public string m_pathID;

        [Header("Spawn point")]
        [TagSelector]
        public string m_spawnPointID;
    }
}