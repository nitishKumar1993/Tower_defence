using TowerDefence;
using UnityEngine;

namespace TowerDefence
{
    public class OrbitalStrike : BaseWeapon //(AOE attack)
    {
        protected override void OnInitialized() { }

        public override void Activate(Transform target = null)
        {
            if (target == null) return;

            Collider[] hits = Physics.OverlapSphere(target.position, m_data.m_range);
            foreach (var hit in hits)
            {
                if (hit.TryGetComponent(out Enemy enemy))
                {
                    enemy.TakeDamage(m_data.m_damage);
                }
            }

            Debug.Log($"{m_data.m_weaponName} orbital strike at {target.position}!");
            Destroy(gameObject, 0.1f);
        }
    }
}