using MEC;
using PrimeTween;
using System.Collections.Generic;
using UnityEngine;

namespace EarthDefender
{
    public class TweenTest : MonoBehaviour
    {
        [SerializeField]
        float duration;
        [SerializeField]
        float targetPositionX;
        Tween tween;
        Sequence sequence;
        private void Start()
        {
            PlayAnimation();
            Timing.RunCoroutine(_DestroyCoroutine().CancelWith(gameObject));
        }
        void PlayAnimation()
        {
            Tween.LocalPositionX(transform, targetPositionX, duration, Ease.Linear);
        }
        IEnumerator<float> _DestroyCoroutine()
        {
            yield return Timing.WaitForSeconds(duration);
            Destroy(gameObject);
        }
    }
}
