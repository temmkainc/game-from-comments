using System;

namespace Comments.Level
{
    public class PlayerHealth
    {
        public event Action DeathEvent;

        public int MaxHealth { get; private set; } = 100;
        public int CurrentHealth { get; private set; }

        private readonly DeathZone _deathZone;
        private readonly PlayerUI _ui;

        public PlayerHealth(DeathZone deathZone, PlayerUI ui)
        {
            _ui = ui;
            _deathZone = deathZone;
            CurrentHealth = MaxHealth;
            _deathZone.PlayerEnteredEvent += On_PlayerEnteredDeathZone;

            CurrentHealth = MaxHealth;
            _ui.SetHealthBar(value: (float)CurrentHealth / MaxHealth);
        }

        public void ResetHealth()
        {
            SetHealth(MaxHealth);
        }

        public void ChangeHealth(int value)
        {
            CurrentHealth += value;
            _ui.SetHealthBar(value: (float)CurrentHealth / MaxHealth);
            CheckForDeath();
        }

        private void SetHealth(int value)
        {
            CurrentHealth = value;
            _ui.SetHealthBar(value: (float)CurrentHealth / MaxHealth);
            CheckForDeath();
        }

        private void CheckForDeath()
        {
            if (CurrentHealth <= 0)
            {
                DeathEvent?.Invoke();
            }
        }

        private void On_PlayerEnteredDeathZone()
        {
            SetHealth(0);
        }
    }
}
