using Comments.Level;
using DG.Tweening;
using TMPro;
using UnityEngine;
using Zenject;

public class DeathPhraseText : MonoBehaviour
{
    [SerializeField] private RoastingPhrasesSO _phrasesDB;
    [SerializeField] private Vector3 _moveOffset = new Vector3(0, 50f, 0);
    [SerializeField] private float _animationDuration = 1f;
    [SerializeField] private float _fadeInAlpha = 1f;

    private Player _player;
    private TMP_Text _text;
    private Vector3 _initialPosition;

    private Tween _moveTween;
    private Tween _fadeTween;

    [Inject]
    public void Construct(Player player)
    {
        _player = player;
    }

    private void Awake()
    {
        _text = GetComponent<TMP_Text>();
        _text.color = new Color(_text.color.r, _text.color.g, _text.color.b, 0f);
        _initialPosition = _text.rectTransform.localPosition;
    }

    private void Start()
    {
        _player.Health.DeathEvent += ShowRandomPhrase;
    }

    private void OnDestroy()
    {
        _player.Health.DeathEvent -= ShowRandomPhrase;
    }

    public void ShowRandomPhrase()
    {
        _moveTween?.Kill();
        _fadeTween?.Kill();

        _text.rectTransform.localPosition = _initialPosition;
        _text.color = new Color(_text.color.r, _text.color.g, _text.color.b, 0f);

        string phrase = _phrasesDB.GetRandomPhrase();
        _text.text = phrase;

        _fadeTween = _text.DOFade(_fadeInAlpha, _animationDuration / 2f).SetEase(Ease.OutQuad);

        _moveTween = _text.rectTransform
            .DOLocalMove(_initialPosition + _moveOffset, _animationDuration)
            .SetEase(Ease.OutCubic)
            .OnComplete(ResetState);
    }

    private void ResetState()
    {
        _fadeTween = _text.DOFade(0f, _animationDuration / 2f).SetEase(Ease.OutQuad)
            .OnComplete(() =>
            {
                _text.rectTransform.localPosition = _initialPosition;
                _text.text = string.Empty;
            });
    }
}
