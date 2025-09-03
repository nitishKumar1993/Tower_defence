using TowerDefence;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace TowerDefence
{
    public class WeaponButtonUI : MonoBehaviour
    {
        [SerializeField] private WeaponData m_weaponData;
        [SerializeField] private Image m_icon;
        [SerializeField] private TextMeshProUGUI m_costText;
        [SerializeField] private Image m_cooldownOverlay;

        [SerializeField] private Button m_button;

        private void Awake()
        {
            m_button.onClick.AddListener(OnButtonClicked);
        }

        private void Start()
        {
            if (m_icon != null && m_weaponData.m_prefab != null)
                m_icon.sprite = m_weaponData.m_prefab.GetComponentInChildren<SpriteRenderer>()?.sprite;

            m_costText.text = string.Format($"{m_weaponData.m_weaponName}\n{m_weaponData.m_cost}");
        }

        private void Update()
        {
            bool canAfford = GameManager.Instance.SpendCurrency(0) || GameManager.Instance.SpendCurrency(m_weaponData.m_cost); // peek only
            bool isReady = CooldownManager.IsReady(m_weaponData);

            m_button.interactable = canAfford && isReady;

            if (!isReady)
            {
                float remaining = CooldownManager.GetRemainingTime(m_weaponData);
                m_cooldownOverlay.fillAmount = remaining / m_weaponData.m_cooldown;
            }
            else
            {
                m_cooldownOverlay.fillAmount = 0f;
            }
        }

        private void OnButtonClicked()
        {
            WeaponDeploymentManager.Instance.SelectWeapon(m_weaponData);
        }
    }
}