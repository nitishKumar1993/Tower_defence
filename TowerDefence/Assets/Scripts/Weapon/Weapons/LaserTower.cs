using TowerDefence;
using UnityEngine;

namespace TowerDefence
{
    public class LaserTower : MonoBehaviour //(auto-attack tower)
    {
        [SerializeField] private WeaponData data;
        private float fireCooldown = 0f;

        private void Start()
        {
            if (data == null)
                Debug.LogError("TeslaTower has no WeaponData assigned!");
        }

        private void Update()
        {
            fireCooldown -= Time.deltaTime;
            if (fireCooldown <= 0f)
            {
                Enemy target = FindNearestEnemy();
                if (target != null)
                {
                    Debug.Log($"{data.m_weaponName} zapped {target.name}! with {data.m_damage} damage");
                    target.TakeDamage(data.m_damage);
                    fireCooldown = data.m_cooldown;
                }
            }
        }

        private Enemy FindNearestEnemy()
        {
            Enemy[] enemies = FindObjectsOfType<Enemy>();
            Enemy nearest = null;
            float minDist = Mathf.Infinity;

            foreach (Enemy e in enemies)
            {
                float dist = Vector3.Distance(transform.position, e.transform.position);
                if (dist < minDist && dist <= data.m_range)
                {
                    minDist = dist;
                    nearest = e;
                }
            }
            return nearest;
        }
    }
}