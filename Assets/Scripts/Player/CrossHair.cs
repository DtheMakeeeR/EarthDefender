using System;
using UnityEngine;
using UnityEngine.InputSystem;
using Utilities;

namespace EarthDefender
{
    public class CrossHair : MonoBehaviour
    {
        [SerializeField]
        Camera cam;
        private void Update()
        {
            MoveToCursor();
        }

        private void MoveToCursor()
        {
            Vector2 mousePosition = Mouse.current.position.ReadValue();
            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePosition).With(z:transform.position.z);
            transform.position = worldPosition;
        }
    }
}
