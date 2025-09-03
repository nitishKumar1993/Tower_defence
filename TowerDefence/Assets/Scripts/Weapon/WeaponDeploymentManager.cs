using TowerDefence;
using UnityEngine;

namespace TowerDefence
{
    public class WeaponDeploymentManager : MonoBehaviour
    {
        public static WeaponDeploymentManager Instance;

        private WeaponData m_selectedWeapon;
        private GameObject m_ghostInstance;

        [SerializeField] private LayerMask m_groundMask;

        private void Awake()
        {
            Instance = this;
        }

        public void SelectWeapon(WeaponData weapon)
        {
            m_selectedWeapon = weapon;
            CreateGhost();
        }

        private void Update()
        {
            if (m_selectedWeapon == null) return;

            UpdateGhost();

            if (Input.GetMouseButtonDown(0)) // Left-click to place
            {
                TryPlaceWeapon();
            }
            else if (Input.GetMouseButtonDown(1)) // Right-click to cancel
            {
                CancelPlacement();
            }
        }

        private void CreateGhost()
        {
            if (m_ghostInstance != null) Destroy(m_ghostInstance);

            if (m_selectedWeapon.m_prefab != null)
            {
                m_ghostInstance = Instantiate(m_selectedWeapon.m_prefab);
                foreach (var c in m_ghostInstance.GetComponentsInChildren<Collider>())
                    c.enabled = false; // disable collisions

                if (!m_ghostInstance.GetComponent<PlacementGhost>())
                    m_ghostInstance.AddComponent<PlacementGhost>();
            }
        }

        private void UpdateGhost()
        {
            if (m_ghostInstance == null) return;

            Vector3 pos = GetMouseWorldPosition();
            m_ghostInstance.transform.position = pos;

            bool canPlace = GameManager.Instance.PlayerCanAfford(m_selectedWeapon.m_cost) &&
                            CooldownManager.IsReady(m_selectedWeapon);

            m_ghostInstance.GetComponent<PlacementGhost>().SetValid(canPlace);
        }

        private void TryPlaceWeapon()
        {
            if (m_ghostInstance == null || m_selectedWeapon == null) return;

            bool canPlace = GameManager.Instance.SpendCurrency(m_selectedWeapon.m_cost) &&
                            CooldownManager.IsReady(m_selectedWeapon);

            if (canPlace)
            {
                Vector3 pos = m_ghostInstance.transform.position;
                WeaponFactory.CreateWeapon(m_selectedWeapon, pos);
                CooldownManager.SetCooldown(m_selectedWeapon);

                CancelPlacement();
            }
        }

        private void CancelPlacement()
        {
            if (m_ghostInstance != null) Destroy(m_ghostInstance);
            m_selectedWeapon = null;
        }

        private Vector3 GetMouseWorldPosition()
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit, 100f, m_groundMask))
            {
                return hit.point;
            }
            return Vector3.zero;
        }
    }
}