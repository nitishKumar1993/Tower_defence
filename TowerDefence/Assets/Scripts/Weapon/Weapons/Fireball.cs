using TowerDefence;
using UnityEngine;

namespace TowerDefence
{
    public class Fireball : BaseWeapon //(projectile ability)
    {
        protected override void OnInitialized() { }

        public override void Activate(Transform target = null)
        {
            if (target == null) return;
            StartCoroutine(MoveToTarget(target));
        }

        private System.Collections.IEnumerator MoveToTarget(Transform target)
        {
            while (target != null && Vector3.Distance(transform.position, target.position) > 0.1f)
            {
                transform.position = Vector3.MoveTowards(transform.position, target.position, 10f * Time.deltaTime);
                yield return null;
            }

            if (target != null && target.TryGetComponent(out Enemy enemy))
            {
                enemy.TakeDamage(m_data.m_damage);
                Debug.Log($"{m_data.m_weaponName} hit {enemy.name}!");
            }

            Destroy(gameObject);
        }
    }
}