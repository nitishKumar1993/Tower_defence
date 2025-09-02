using UnityEngine;
using UnityEngine.UI;

namespace TowerDefence
{
    public class UIManager : MonoBehaviour
    {
        [Header("UI References")]
        [SerializeField] private Text m_healthText;
        [SerializeField] private Text m_currencyText;
        [SerializeField] private GameObject gameOverPanel;

        private void OnEnable()
        {
            EventBus.OnHealthChanged += UpdateHealthUI;
            EventBus.OnCurrencyChanged += UpdateCurrencyUI;
            EventBus.OnGameOver += ShowGameOver;
        }

        private void OnDisable()
        {
            EventBus.OnHealthChanged -= UpdateHealthUI;
            EventBus.OnCurrencyChanged -= UpdateCurrencyUI;
            EventBus.OnGameOver -= ShowGameOver;
        }

        private void UpdateHealthUI(int health)
        {
            m_healthText.text = $"Health: {health}";
        }

        private void UpdateCurrencyUI(int currency)
        {
            m_currencyText.text = $"Currency: {currency}";
        }

        private void ShowGameOver()
        {
            gameOverPanel.SetActive(true);
        }
    }
}