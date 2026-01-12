using PrimeTween;
using UnityEngine;

namespace EarthDefender
{
    public class FallingItem : MonoBehaviour
    {
        [SerializeField]
        float duration;
        private void Start()
        {
            PlayAnimation();
        }
        void PlayAnimation()
        {
            Tween.LocalPositionY(transform, GameManager.Instance.Player.transform.position.y, duration, Ease.Linear);
        }
    }
}
