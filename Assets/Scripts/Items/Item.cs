using UnityEngine;

namespace EarthDefender
{
    public abstract class Item : MonoBehaviour
    {
        [SerializeField]
        protected float amount;

        void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent(out Player player))
            {
                ActiveateItem(player);
                Destroy(gameObject);
            }
        }

        protected abstract void ActiveateItem(Player player);
    }
}
