using System.Collections;
using TowerDefence;
using UnityEngine;

namespace TowerDefence
{
    public class WaveManager : MonoBehaviour
    {
        [Header("Wave Settings")]
        [SerializeField] private WaveData[] m_waves; // Drag & drop WaveData SOs
        [SerializeField] private Transform[] m_pathPoints; // Waypoints for enemies
        [SerializeField] private Transform m_spawnPoint;

        private int currentWaveIndex = 0;
        private bool isSpawning = false;

        public void StartNextWave()
        {
            if (!isSpawning && currentWaveIndex < m_waves.Length)
            {
                StartCoroutine(SpawnWave(m_waves[currentWaveIndex]));
                currentWaveIndex++;
            }
        }

        private IEnumerator SpawnWave(WaveData wave)
        {
            isSpawning = true;

            foreach (var enemyInfo in wave.m_enemiesToSpawn)
            {
                for (int i = 0; i < enemyInfo.m_count; i++)
                {
                    SpawnEnemy(enemyInfo.m_enemyData);
                    yield return new WaitForSeconds(enemyInfo.m_spawnInterval);
                }
            }

            isSpawning = false;
        }

        private void SpawnEnemy(EnemyData data)
        {
            GameObject enemyObj = Instantiate(data.m_prefab, m_spawnPoint.position, Quaternion.identity);
            Enemy enemy = enemyObj.GetComponent<Enemy>();
            enemy.Initialize(data, m_pathPoints);
        }
    }
}