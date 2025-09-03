using System;
using UnityEngine;
using UnityEngine.Events;

namespace TowerDefence
{
    public static class EventBus
    {
        public enum GameState { MainMenu, InGame, GamePause, GameOver }

        //Game state events
        public static UnityAction<GameState> OnGameStateChange;

        // Currency events
        public static Action<int> OnCurrencyChanged;

        // Health events
        public static Action<int> OnHealthChanged;

        // Game events
        public static Action OnGameOver;
        public static Action OnGameStart;
    }
}