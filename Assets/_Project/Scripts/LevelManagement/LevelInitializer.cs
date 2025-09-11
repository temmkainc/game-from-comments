using UnityEngine;
using Zenject;

namespace Comments.Level
{
    public class LevelInitializer : IInitializable
    {
        private readonly Player _player;
        private readonly LevelContainer _levelContainer;

        public LevelInitializer(Player player, LevelContainer levelContainer)
        {
            _player = player;
            _levelContainer = levelContainer;
        }

        public void Initialize()
        {
            _player.transform.position = _levelContainer.SpawnPoint.position;
            Camera.main.GetComponent<CameraFollow2D>().target = _player.transform;
        }
    }
}
