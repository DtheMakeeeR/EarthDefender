using PrimeTween;
using System;
using UnityEngine;

namespace EarthDefender
{
    public class BossSpawn : MonoBehaviour
    {
        [SerializeField]
        Boss boss;
        [SerializeField]
        Vector3 targetPosition;
        [SerializeField]
        float appearDuration;
        [SerializeField]
        Vector3 rightPosition;
        [SerializeField]
        float moveDuration;
        void Start()
        {
            StartAppearAnimation();
        }

        private void StartAppearAnimation()
        {
            Tween.LocalPosition(transform, targetPosition, appearDuration, Ease.Linear)
            .OnComplete(StartMoveAnimation);
           // Sequence.Create(cycles: 2, Sequence.SequenceCycleMode.Yoyo)
           //     .Chain(Tween.LocalPosition(transform, rightPosition, moveDuration, Ease.InOutBack, -1, CycleMode.Yoyo)).SetRemainingCycles(-1);            
        }
        private void StartMoveAnimation()
        {
            boss.IsInvinsible = false;
            Tween.LocalPosition(transform, rightPosition, moveDuration, Ease.InOutSine, -1, CycleMode.Yoyo);           

        }
    }
}
