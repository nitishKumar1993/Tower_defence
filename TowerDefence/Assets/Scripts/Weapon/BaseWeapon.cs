using TowerDefence;
using UnityEngine;

namespace TowerDefence
{
    public abstract class BaseWeapon : MonoBehaviour
    {
        protected WeaponData m_data;

        public void Initialize(WeaponData weaponData)
        {
            m_data = weaponData;
            OnInitialized();
        }

        protected abstract void OnInitialized();

        public abstract void Activate(Transform target = null);
    }
}