using System;
using Unity.VisualScripting;
using UnityEngine;
namespace EarthDefender
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField]
        float moveSpeed = 5f;
        [SerializeField]
        float smoothness = 0.1f;

        [SerializeField]
        InputReader input;

        [Header("Camera Bounds")]
        [SerializeField]
        Transform CameraFollow;
        [SerializeField]
        float minX = -3f;
        [SerializeField]
        float maxX = 3f;
        //[SerializeField]
        //float minY = -3f;
        //[SerializeField]
        //float maxY = 3f;

        Vector2 moveInput;
        Vector3 currentVelocity;
        Vector3 targetPosition;

        private void Start()
        {
            input.Move += direction => moveInput = direction.normalized;
            input.EnablePlayerActions();
        }
        private void Update()
        {
            Move(moveInput);
        }

        private void Move(Vector3 direction)
        {
            //if (direction.sqrMagnitude > 0.01f)
            {
                targetPosition += (new Vector3(moveInput.x, 0, 0) * (moveSpeed * Time.deltaTime));
                targetPosition.y = transform.position.y;

                //var minPlayerY = CameraFollow.position.y + minY;
                //var maxPlayerY = CameraFollow.position.y + maxY;
                ClampTargetPosition();
                //targetPosition.y = Mathf.Clamp(targetPosition.y, minPlayerY, maxPlayerY);

                transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref currentVelocity, smoothness);
                //transform.position += targetPosition * moveSpeed * Time.deltaTime;
            }
            //else
            //{
            //    ClampTargetPosition();
            //    transform.position = targetPosition;
            //}
        }

        private void ClampTargetPosition()
        {
            var minPlayerX = CameraFollow.position.x + minX;
            var maxPlayerX = CameraFollow.position.x + maxX;
            targetPosition.x = Mathf.Clamp(targetPosition.x, minPlayerX, maxPlayerX);
        }
    }
}
