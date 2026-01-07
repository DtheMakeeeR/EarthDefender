using UnityEngine;

namespace EarthDefender
{
    public class HealthItem : Item
    {
        void OnTriggerEnter2D(Collider2D other)
        {
            Debug.Log($"other: {other.gameObject.name}");
            other.GetComponent<Player>().AddHealth((int)amount);
            Destroy(gameObject);
        }
    }
}
