using Comments.Player;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Comments.Level
{
    public class Player : MonoBehaviour
    {
        public PlayerHealth Health { get; private set; }

        [field: SerializeField]
        public Animator Animator { get; private set; }
        [field: SerializeField]
        public Transform ItemInHand { get; private set; }

        private PlayerInputContainer _inputContainer;
        private LevelContainer _levelContainer;
        private Resizer _resizer;
        private GameManager _gameManager;
        private PlayerMovement _movement;

        [Inject]
        public void Construct(PlayerInputContainer playerInputContainer, LevelContainer levelContainer, GameManager gameManager)
        {
            _levelContainer = levelContainer;
            _gameManager = gameManager;
            _inputContainer = playerInputContainer;
            _resizer = new Resizer(transform);
            _movement = GetComponent<PlayerMovement>();
            Health = new PlayerHealth(_levelContainer.DeathZone);
            SubscribeToEvents();
        }

        private void OnDestroy()
        {
            UnsubscriveFromEvents();
        }

        private void SubscribeToEvents()
        {
            _inputContainer.SizeButton.onClick.AddListener(On_SizeButtonClicked);
            Health.DeathEvent += On_Death;
        }

        private void UnsubscriveFromEvents()
        {
            _inputContainer.SizeButton.onClick.RemoveListener(On_SizeButtonClicked);
            Health.DeathEvent -= On_Death;
        }

        private void On_SizeButtonClicked()
        {
            var isMinimazied = _resizer.Resize();
            var image = _inputContainer.SizeButton.GetComponent<Image>();
            image.sprite = isMinimazied ? _inputContainer.DownSizeSprite : _inputContainer.UpSizeSprite;
        }

        private void On_Death()
        {
            Respawn();
        }

        private void Respawn()
        {
            _movement.Stop();
            transform.position = _levelContainer.SpawnPoint.position;
        }
    }
}
