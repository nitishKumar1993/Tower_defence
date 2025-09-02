using System;
using UnityEngine;

namespace TowerDefence
{
    public static class EventBus
    {
        // Currency events
        public static Action<int> OnCurrencyChanged;

        // Health events
        public static Action<int> OnHealthChanged;

        // Game events
        public static Action OnGameOver;
        public static Action OnGameStart;
    }
}