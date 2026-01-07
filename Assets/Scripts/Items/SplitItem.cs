using UnityEngine;

namespace EarthDefender
{
    public class SplitItem : Item
    {
        void OnTriggerEnter2D(Collider2D other)
        {
            Debug.Log($"other: {other.gameObject.name}");
            other.GetComponent<Player>().IncreaseShotsCount((int)amount);
            Destroy(gameObject);
        }
    }
}
