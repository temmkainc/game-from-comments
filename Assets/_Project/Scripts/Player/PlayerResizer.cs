using DG.Tweening;
using UnityEngine;
public class Resizer
{
    private readonly Transform _target;
    private Tween _currentTween;

    private const float MINIMIZED_SCALE = 0.2f;
    private const float NORMAL_SCALE = 0.5f;
    private const float SCALE_DURATION = 0.3f;

    private bool _isMinimized = false;

    public Resizer(Transform target)
    {
        _target = target;
    }

    public bool Resize()
    {

        var newScale = _isMinimized ? NORMAL_SCALE : MINIMIZED_SCALE;
        _isMinimized = !_isMinimized;
        _currentTween?.Kill();

        _currentTween = _target.DOScale(newScale, SCALE_DURATION)
            .SetEase(Ease.InOutSine);

        return _isMinimized;
    }
}
