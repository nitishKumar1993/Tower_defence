using UnityEngine;

namespace TowerDefence
{
    [CreateAssetMenu(fileName = "EnemyData", menuName = "Game Data/Enemy Data")]
    public class EnemyData : ScriptableObject
    {
        [Header("Stats")]
        public float m_moveSpeed = 2f;
        public int m_maxHealth = 5;
        public int m_reward = 10;

        [Header("Appearance")]
        public GameObject m_prefab; // Assign enemy prefab
    }
}