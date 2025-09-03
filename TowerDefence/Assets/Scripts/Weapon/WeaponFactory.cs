using TowerDefence;
using UnityEngine;

namespace TowerDefence
{
    public static class WeaponFactory
    {
        public static BaseWeapon CreateWeapon(WeaponData data, Vector3 position, Transform target = null)
        {
            GameObject obj = Object.Instantiate(data.m_prefab, position, Quaternion.identity);
            BaseWeapon weapon = obj.GetComponent<BaseWeapon>();
            weapon.Initialize(data);

            // For one-time weapons like Fireball or OrbitalStrike
            if (target != null) weapon.Activate(target);

            return weapon;
        }
    }
}