using System;
using UnityEngine;
using Utilities;

namespace EarthDefender
{
    public class GunAimer : MonoBehaviour
    {
        [SerializeField]
        Transform crossHair;
        [SerializeField]
        float smoothness = 5f;
        [SerializeField]
        float minDegree = -90f;
        [SerializeField]
        float maxDegree = 90f;
        private void Update()
        {
            RotateAtCrosshair();
        }

        private void RotateAtCrosshair()
        {
            Vector3 direction = crossHair.position - transform.position;
            float rawAngle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;

            rawAngle = NormalizeAngle(rawAngle);

            if (rawAngle < minDegree || rawAngle > maxDegree)
            {
                if (Mathf.Abs(rawAngle + maxDegree) < Mathf.Abs(rawAngle + minDegree))
                    rawAngle = minDegree;  // Левая граница
                else
                    rawAngle = maxDegree;   // Правая граница
            }

            float currentAngle = NormalizeAngle(transform.rotation.eulerAngles.z);
            float newAngle = Mathf.MoveTowards(currentAngle, rawAngle,
                                              smoothness * Time.deltaTime * Mathf.Abs(rawAngle - currentAngle));

            transform.rotation = Quaternion.Euler(0, 0, newAngle);
        }

        private float NormalizeAngle(float angle)
        {
            angle %= 360;
            if (angle > 180)
                angle -= 360;
            else if (angle < -180)
                angle += 360;
            return angle;
        }
    }
}
