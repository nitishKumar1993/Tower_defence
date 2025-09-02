using TowerDefence;
using UnityEngine;

namespace TowerDefence
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance;

        [Header("Game Data")]
        [SerializeField] private GameSettings m_gameSettings;
        [SerializeField] private PlayerData m_playerData;

        private void Awake()
        {
            // Singleton setup
            if (Instance != null && Instance != this)
            {
                Destroy(gameObject);
                return;
            }
            Instance = this;
        }

        private void Start()
        {
            if (!m_playerData.m_initialized)
                m_playerData.Initialize(m_gameSettings);

            EventBus.OnHealthChanged?.Invoke(m_playerData.m_currentHealth);
            EventBus.OnCurrencyChanged?.Invoke(m_playerData.m_currentCurrency);

            EventBus.OnGameStart?.Invoke();
        }

        #region Health
        public void TakeDamage(int damage)
        {
            m_playerData.m_currentHealth -= damage;
            EventBus.OnHealthChanged?.Invoke(m_playerData.m_currentHealth);

            if (m_playerData.m_currentHealth <= 0)
            {
                m_playerData.m_currentHealth = 0;
                EventBus.OnGameOver?.Invoke();
            }
        }
        #endregion

        #region Currency
        public bool SpendCurrency(int amount)
        {
            if (m_playerData.m_currentCurrency >= amount)
            {
                m_playerData.m_currentCurrency -= amount;
                EventBus.OnCurrencyChanged?.Invoke(m_playerData.m_currentCurrency);
                return true;
            }
            return false;
        }

        public void EarnCurrency(int amount)
        {
            m_playerData.m_currentCurrency += amount;
            EventBus.OnCurrencyChanged?.Invoke(m_playerData.m_currentCurrency);
        }
        #endregion
    }
}