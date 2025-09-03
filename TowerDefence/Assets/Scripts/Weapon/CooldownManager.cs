using System.Collections.Generic;
using TowerDefence;
using UnityEngine;

namespace TowerDefence
{
    public class CooldownManager : MonoBehaviour
    {
        private static Dictionary<WeaponData, float> cooldownTimers = new();

        public static bool IsReady(WeaponData data)
        {
            return !cooldownTimers.ContainsKey(data) || Time.time >= cooldownTimers[data];
        }

        public static void SetCooldown(WeaponData data)
        {
            cooldownTimers[data] = Time.time + data.m_cooldown;
        }
    }
}