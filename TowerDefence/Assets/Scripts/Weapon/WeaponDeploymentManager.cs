using TowerDefence;
using UnityEngine;

namespace TowerDefence
{
    public class WeaponDeploymentManager : MonoBehaviour
    {
        public static WeaponDeploymentManager Instance;

        private WeaponData selectedWeapon;

        private void Awake()
        {
            Instance = this;
        }

        public void SelectWeapon(WeaponData weapon)
        {
            selectedWeapon = weapon;
            Debug.Log($"Selected weapon: {weapon.m_weaponName}");
        }

        private void Update()
        {
            if (selectedWeapon == null) return;

            if (Input.GetMouseButtonDown(0))
            {
                Vector3 worldPos = GetMouseWorldPosition();

                if (GameManager.Instance.SpendCurrency(selectedWeapon.m_cost) && CooldownManager.IsReady(selectedWeapon))
                {
                    // For AOE / projectile weapons, pass target
                    Transform target = FindEnemyAt(worldPos);

                    WeaponFactory.CreateWeapon(selectedWeapon, worldPos, target);
                    CooldownManager.SetCooldown(selectedWeapon);
                }

                selectedWeapon = null; // Deselect after use
            }
        }

        private Vector3 GetMouseWorldPosition()
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                return hit.point;
            }
            return Vector3.zero;
        }

        private Transform FindEnemyAt(Vector3 position)
        {
            Collider[] hits = Physics.OverlapSphere(position, 1f);
            foreach (var hit in hits)
            {
                if (hit.TryGetComponent(out Enemy enemy))
                    return enemy.transform;
            }
            return null;
        }
    }
}