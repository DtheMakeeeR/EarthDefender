using UnityEngine;
using System.Collections.Generic;
using MEC;
namespace EarthDefender
{
    public class ParalaxController : MonoBehaviour
    {
        [SerializeField] Transform[] backgrounds; // Array of background layers
        [SerializeField] float paralaxSmoothing = 0.05f; // How smooth the parallax effect is
        [SerializeField] float multiplier = 15f; // How much the parallax effect increments per layer
        [SerializeField] float speed = 4f;
        [SerializeField] float smoothTime = 0.5f;

        [SerializeField]
        bool isMoving;

        float stoppingVelocity;
        void Update()
        {
            if (isMoving)
            {
                MakeParalax();
            }

        }

        private void MakeParalax()
        {
            for (var i = 0; i < backgrounds.Length; i++)
            {
                var parallax = -speed * ((i + 1) * multiplier);
                var targetX = backgrounds[i].position.x + parallax;

                var targetPosition = new Vector3(targetX, backgrounds[i].position.y, backgrounds[i].position.z);

                backgrounds[i].position = Vector3.Lerp(backgrounds[i].position, targetPosition, paralaxSmoothing * Time.deltaTime);
            }
        }
        public void StopParalax()
        {
            Timing.RunCoroutine(_StoppingCoroutine().CancelWith(gameObject));
        }
        IEnumerator<float> _StoppingCoroutine()
        {
            while(speed > 0.1f)
            {
                speed = Mathf.SmoothDamp(speed, 0f, ref stoppingVelocity, smoothTime);
                yield return Timing.WaitForOneFrame;
            }
            isMoving = false;
        }
    }
}
