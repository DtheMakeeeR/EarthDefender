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
        InputReader input;

        Vector2 moveInput;

        private void Start()
        {
            input.Move += direction => moveInput = direction;
            input.EnablePlayerActions();
        }
        private void Update()
        {
            Move(moveInput);
        }

        private void Move(Vector3 direction)
        {
            if (direction.sqrMagnitude > 0.01f)
            {
                transform.position += direction * (Time.deltaTime * moveSpeed);
            }
        }
    }
}
