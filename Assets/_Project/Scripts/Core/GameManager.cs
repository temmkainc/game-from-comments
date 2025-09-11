using UnityEngine;
using Zenject;

namespace Comments.Level
{
    public class GameManager : IInitializable
    {
        private readonly Player _player;

        [Inject]
        public GameManager(Player player)
        {
            _player = player;

        }

        public void Initialize()
        {
            _player.Health.DeathEvent += On_PlayerDeath;
        }

        private static void On_PlayerDeath()
        {
            Debug.Log("Player has died. Game Over.");
        }
    }
}
