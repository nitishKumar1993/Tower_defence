using UnityEngine;

namespace TowerDefence
{
    [CreateAssetMenu(fileName = "GameSettings", menuName = "Game Data/Game Settings")]
    public class GameSettings : ScriptableObject
    {
        [Header("Starting Values")]
        public int m_startingHealth = 10;
        public int m_startingCurrency = 100;
    }
}