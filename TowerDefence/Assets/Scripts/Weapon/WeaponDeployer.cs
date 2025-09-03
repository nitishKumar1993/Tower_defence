using TowerDefence;
using UnityEngine;

namespace TowerDefence
{
    public class WeaponDeployer : MonoBehaviour
    {
        [SerializeField] private Camera mainCamera;

        public void DeployWeapon(WeaponData weaponData)
        {
            if (!CooldownManager.IsReady(weaponData)) return;
            if (!GameManager.Instance.SpendCurrency(weaponData.m_cost)) return;

            Vector3 deployPos = Vector3.zero;
            Transform target = null;

            if (weaponData.m_weaponType == WeaponType.Mine)
            {
                // Place mine at clicked ground position
                if (Physics.Raycast(mainCamera.ScreenPointToRay(Input.mousePosition), out RaycastHit hit))
                    deployPos = hit.point;
            }
            else if (weaponData.m_weaponType == WeaponType.Fireball || weaponData.m_weaponType == WeaponType.OrbitalStrike)
            {
                // Cast target enemy
                if (Physics.Raycast(mainCamera.ScreenPointToRay(Input.mousePosition), out RaycastHit hit))
                    target = hit.transform;
            }

            if (weaponData.m_weaponType == WeaponType.Mine && deployPos != Vector3.zero)
            {
                WeaponFactory.CreateWeapon(weaponData, deployPos);
            }
            else if ((weaponData.m_weaponType == WeaponType.Fireball || weaponData.m_weaponType == WeaponType.OrbitalStrike) && target != null)
            {
                WeaponFactory.CreateWeapon(weaponData, target.position, target);
            }

            CooldownManager.SetCooldown(weaponData);
        }
    }
}