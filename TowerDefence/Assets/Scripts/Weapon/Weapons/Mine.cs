using TowerDefence;
using UnityEngine;

namespace TowerDefence
{
    public class Mine : BaseWeapon //(explodes when enemy enters range)
    {
        protected override void OnInitialized() { }

        public override void Activate(Transform target = null)
        {
            // Mines don’t activate manually – wait for trigger
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out Enemy enemy))
            {
                enemy.TakeDamage(m_data.m_damage);
                Debug.Log($"{m_data.m_weaponName} exploded on {enemy.name}!");
                Destroy(gameObject);
            }
        }
    }
}