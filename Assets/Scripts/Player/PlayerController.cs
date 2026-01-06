using System;
using Unity.VisualScripting;
using UnityEngine;
namespace EarthDefender
{
    public class PlayerController : MonoBehaviour
    {
        [Header("Movement")]
        [SerializeField]
        float moveSpeed = 5f;
        [SerializeField]
        float smoothness = 0.1f;

        [SerializeField]
        InputReader input;

        [Header("Weapon")]
        [SerializeField]
        Weapon mainWeapon;

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
        bool isAttacking;



        private void Start()
        {
            input.Move += direction => moveInput = direction.normalized;
            input.Attack += val => isAttacking = val;
            input.EnablePlayerActions();
        }
        private void Update()
        {
            Move();
            Shoot();
        }

        private void Shoot()
        {
            if (isAttacking)
            {
                mainWeapon.Fire();
            }
        }

        private void Move()
        {
            {
                targetPosition += (new Vector3(moveInput.x, 0, 0) * (moveSpeed * Time.deltaTime));
                targetPosition.y = transform.position.y;

                ClampTargetPosition();

                transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref currentVelocity, smoothness);
            }
        }

        private void ClampTargetPosition()
        {
            var minPlayerX = CameraFollow.position.x + minX;
            var maxPlayerX = CameraFollow.position.x + maxX;
            targetPosition.x = Mathf.Clamp(targetPosition.x, minPlayerX, maxPlayerX);
        }
    }
}
