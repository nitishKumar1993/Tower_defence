using TowerDefence;
using UnityEngine;

namespace TowerDefence
{
    public class Enemy : MonoBehaviour
    {
        [SerializeField] private EnemyData data;

        private int currentHealth;
        private Transform[] path; // Assigned by WaveManager
        private int waypointIndex = 0;

        public void Initialize(EnemyData enemyData)
        {
            data = enemyData;
            currentHealth = data.m_maxHealth;
            path = PathManager.GetPath(data.m_pathID);
            waypointIndex = 0;
        }

        private void Update()
        {
            MoveAlongPath();
        }

        private void MoveAlongPath()
        {
            if (path == null || waypointIndex >= path.Length) return;

            Transform targetPoint = path[waypointIndex];
            Vector3 dir = (targetPoint.position - transform.position).normalized;

            transform.position += dir * data.m_moveSpeed * Time.deltaTime;

            // If close to waypoint then go to next
            if (Vector3.Distance(transform.position, targetPoint.position) < 0.1f)
            {
                waypointIndex++;

                if (waypointIndex >= path.Length)
                {
                    ReachEnd();
                }
            }
        }

        public void TakeDamage(int damage)
        {
            currentHealth -= damage;

            if (currentHealth <= 0)
            {
                Die();
            }
        }

        private void Die()
        {
            GameManager.Instance.EarnCurrency(data.m_reward);
            Destroy(gameObject);
        }

        private void ReachEnd()
        {
            GameManager.Instance.TakeDamage(1); // Damage player base
            Destroy(gameObject);
        }
    }
}