using TowerDefence;
using UnityEngine;

namespace TowerDefence
{
    [CreateAssetMenu(fileName = "WaveData", menuName = "Game Data/Wave Data")]
    public class WaveData : ScriptableObject
    {
        [System.Serializable]
        public class EnemySpawnInfo
        {
            public EnemyData m_enemyData;
            public int m_count = 5;
            public float m_spawnInterval = 1f;
        }

        public EnemySpawnInfo[] m_enemiesToSpawn;
    }
}