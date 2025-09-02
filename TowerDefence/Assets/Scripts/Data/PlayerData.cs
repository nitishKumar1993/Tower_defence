using UnityEngine;

namespace TowerDefence
{
    [CreateAssetMenu(fileName = "PlayerData", menuName = "Game Data/Player Data")]
    public class PlayerData : ScriptableObject
    {
        [Header("Runtime Values")]
        public int m_currentHealth;
        public int m_currentCurrency;

        [HideInInspector] public bool m_initialized = false;

        public void Initialize(GameSettings settings)
        {
            m_currentHealth = settings.m_startingHealth;
            m_currentCurrency = settings.m_startingCurrency;
            m_initialized = true;
        }
    }
}