using TowerDefence;
using UnityEngine;
using UnityEngine.UI;

namespace TowerDefence
{
    public class WeaponButtonUI : MonoBehaviour
    {
        [SerializeField] private WeaponData weaponData;
        [SerializeField] private Image icon;
        [SerializeField] private Text costText;
        [SerializeField] private Image cooldownOverlay;

        private Button button;

        private void Awake()
        {
            button = GetComponent<Button>();
            button.onClick.AddListener(OnButtonClicked);
        }

        private void Start()
        {
            if (icon != null && weaponData.m_prefab != null)
                icon.sprite = weaponData.m_prefab.GetComponentInChildren<SpriteRenderer>()?.sprite;

            costText.text = $"${weaponData.m_cost}";
        }

        private void Update()
        {
            bool canAfford = GameManager.Instance.SpendCurrency(0) || GameManager.Instance.SpendCurrency(weaponData.m_cost); // peek only
            bool isReady = CooldownManager.IsReady(weaponData);

            button.interactable = canAfford && isReady;

            if (!isReady)
            {
                float remaining = CooldownManager.GetRemainingTime(weaponData);
                cooldownOverlay.fillAmount = remaining / weaponData.m_cooldown;
            }
            else
            {
                cooldownOverlay.fillAmount = 0f;
            }
        }

        private void OnButtonClicked()
        {
            WeaponDeploymentManager.Instance.SelectWeapon(weaponData);
        }
    }
}