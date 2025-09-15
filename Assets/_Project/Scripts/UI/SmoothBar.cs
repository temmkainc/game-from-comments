using Cysharp.Threading.Tasks;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

namespace Comments.UI
{
    public class SmoothBar : Image
    {
        private const float SHRINK_LERP_SPEED = 0.3f;
        private const float GROW_LERP_SPEED = 0.7f;

        private CancellationTokenSource _cts;

        public void SetValue(float targetValue)
        {
            _cts?.Cancel();
            _cts?.Dispose();
            _cts = new CancellationTokenSource();

            float _lerpSpeed = targetValue < this.fillAmount ? SHRINK_LERP_SPEED : GROW_LERP_SPEED;
            AnimateTo(targetValue, _lerpSpeed, _cts.Token).Forget();
        }

        private async UniTask AnimateTo(float targetValue, float speed, CancellationToken token)
        {
            while (!Mathf.Approximately(this.fillAmount, targetValue))
            {
                if (token.IsCancellationRequested)
                    return;

                this.fillAmount = Mathf.MoveTowards(
                    this.fillAmount,
                    targetValue,
                    speed * Time.deltaTime
                );

                await UniTask.Yield(PlayerLoopTiming.Update, token);
            }

            this.fillAmount = targetValue;
        }
    }
}
