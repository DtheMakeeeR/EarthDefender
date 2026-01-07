using MEC;
using PrimeTween;
using System.Collections.Generic;
using UnityEngine;
using Utilities;

namespace EarthDefender
{
    public class StraightLineMovement : MonoBehaviour
    {
        public enum Direction
        {
            FromLeftToRight,
            FromRightToLeft
        }
        [SerializeField]
        float duration;
        [SerializeField] 
        Direction direction;

        float targetPositionX;
        private void Start()
        {
            if (transform.position.x >= 0) direction = Direction.FromRightToLeft;
            else direction = Direction.FromLeftToRight;


            if(direction == Direction.FromRightToLeft)
            {
                transform.localScale = transform.localScale.With(x: -transform.localScale.x);
                targetPositionX = -transform.position.x - 2f;
            }
            if(direction == Direction.FromLeftToRight)
            {
                targetPositionX = -transform.position.x + 2f;
            }
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
