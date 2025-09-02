using TowerDefence;
using UnityEngine;

namespace TowerDefence
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance;

        [Header("Game Data")]
        [SerializeField] private GameSettings gameSettings;
        [SerializeField] private PlayerData playerData;

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
            if (!playerData.initialized)
                playerData.Initialize(gameSettings);

            EventBus.OnHealthChanged?.Invoke(playerData.m_currentHealth);
            EventBus.OnCurrencyChanged?.Invoke(playerData.m_currentCurrency);

            EventBus.OnGameStart?.Invoke();
        }

        #region Health
        public void TakeDamage(int damage)
        {
            playerData.m_currentHealth -= damage;
            EventBus.OnHealthChanged?.Invoke(playerData.m_currentHealth);

            if (playerData.m_currentHealth <= 0)
            {
                playerData.m_currentHealth = 0;
                EventBus.OnGameOver?.Invoke();
            }
        }
        #endregion

        #region Currency
        public bool SpendCurrency(int amount)
        {
            if (playerData.m_currentCurrency >= amount)
            {
                playerData.m_currentCurrency -= amount;
                EventBus.OnCurrencyChanged?.Invoke(playerData.m_currentCurrency);
                return true;
            }
            return false;
        }

        public void EarnCurrency(int amount)
        {
            playerData.m_currentCurrency += amount;
            EventBus.OnCurrencyChanged?.Invoke(playerData.m_currentCurrency);
        }
        #endregion
    }
}