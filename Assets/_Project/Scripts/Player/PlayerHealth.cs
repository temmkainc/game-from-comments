using System;

namespace Comments.Level
{
    public class PlayerHealth
    {
        public event Action DeathEvent;

        public int MaxHealth { get; private set; } = 100;
        public int CurrentHealth { get; private set; }

        private readonly DeathZone _deathZone;

        public PlayerHealth(DeathZone deathZone)
        {
            _deathZone = deathZone;
            CurrentHealth = MaxHealth;
            _deathZone.PlayerEnteredEvent += On_PlayerEnteredDeathZone;
        }

        public void ChangeHealth(int value)
        {
            CurrentHealth += value;
            CheckForDeath();
        }

        private void CheckForDeath()
        {
            if (CurrentHealth <= 0)
            {
                CurrentHealth = 0;
                DeathEvent?.Invoke();
            }
        }

        private void On_PlayerEnteredDeathZone()
        {
            CurrentHealth = 0;
            CheckForDeath();
        }
    }
}
