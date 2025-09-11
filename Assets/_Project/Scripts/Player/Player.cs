using Comments.Player;
using Cysharp.Threading.Tasks;
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

        private LevelContainer _levelContainer;
        private Resizer _resizer;

        private PlayerInputContainer _inputContainer;
        private PlayerMovement _movement;
        private PlayerUI _ui;

        [Inject]
        public void Construct(PlayerInputContainer playerInputContainer, LevelContainer levelContainer)
        {
            _movement = GetComponent<PlayerMovement>();

            _levelContainer = levelContainer;
            _inputContainer = playerInputContainer;

            _resizer = new Resizer(transform);
            _ui = new PlayerUI(_inputContainer);
            Health = new PlayerHealth(_levelContainer.DeathZone, _ui);

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
            Respawn().AttachExternalCancellation(destroyCancellationToken).Forget();
        }

        private async UniTask Respawn()
        {
            await UniTask.Delay(500);

            _movement.Stop();
            Health.ResetHealth();
            transform.position = _levelContainer.SpawnPoint.position;
        }
    }
}
