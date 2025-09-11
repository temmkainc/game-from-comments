using Cysharp.Threading.Tasks;
using DG.Tweening;
using UnityEngine;

namespace Comments.Level
{
    public class FinishPoint : MonoBehaviour
    {
        [SerializeField] private string _sceneToLoad;

        [Header("Floating Motion")]
        [SerializeField] private float _moveDistance = 0.5f;
        [SerializeField] private float _moveDuration = 1f;

        private void Start()
        {
            transform.DOMoveY(transform.position.y + _moveDistance, _moveDuration)
                     .SetLoops(-1, LoopType.Yoyo)
                     .SetEase(Ease.InOutSine);
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (!collision.TryGetComponent<Player>(out var player))
                return;

            GetComponent<SpriteRenderer>().enabled = false;
            GetComponent<Collider2D>().enabled = false;

            player.Animator.SetTrigger("Eat");
            WaitForEatAndLoad().Forget();
        }

        private async UniTaskVoid WaitForEatAndLoad()
        {
            await UniTask.Delay(1000);

            LevelManager.LoadLevel(_sceneToLoad);
        }
    }
}
