using UnityEngine;

namespace EarthDefender
{
    public class CameraController : MonoBehaviour
    {
        [SerializeField] Transform player;
        [SerializeField] float speed = 2f;

        void LateUpdate()
        {
            // Move the camera along the battlefield at a constant speed
            transform.position += Vector3.right * (speed * Time.deltaTime);
        }
    }
}
