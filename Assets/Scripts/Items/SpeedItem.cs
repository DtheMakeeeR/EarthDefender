using UnityEngine;

namespace EarthDefender
{
    public class SpeedItem : Item
    {
        void OnTriggerEnter2D(Collider2D other)
        {
            other.GetComponent<Player>().IncreaseSpeed(amount);
            Destroy(gameObject);
        }
    }
}
