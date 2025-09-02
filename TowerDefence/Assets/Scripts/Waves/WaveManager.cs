using System.Collections;
using TowerDefence;
using UnityEngine;

namespace TowerDefence
{
    public class WaveManager : MonoBehaviour
    {
        [Header("Wave Settings")]
        [SerializeField] private WaveData[] m_waves;

        private int currentWaveIndex = 0;
        private bool isSpawning = false;


        private void Update()
        {
            //if (Input.GetKeyUp(KeyCode.Space))
            //{
            //    StartNextWave();
            //}
        }

        public void StartNextWave()
        {
            if (!isSpawning && currentWaveIndex < m_waves.Length)
            {
                StartCoroutine(SpawnWave(m_waves[currentWaveIndex]));
                currentWaveIndex++;

                if(currentWaveIndex >= m_waves.Length)
                    currentWaveIndex = 0;
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
            GameObject enemyObj = Instantiate(data.m_prefab, SpawnPointManager.GetSpawnPoint(data.m_spawnPointID).position, Quaternion.identity);
            Enemy enemy = enemyObj.GetComponent<Enemy>();
            enemy.Initialize(data);
        }
    }
}