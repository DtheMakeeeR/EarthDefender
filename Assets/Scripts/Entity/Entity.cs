using System;
using UnityEngine;

namespace EarthDefender
{
    public abstract class Entity : MonoBehaviour
    {
        [SerializeField]
        protected int health;

        public void TakeDamadge(int amount)
        {
            health -= amount;
            if (health <= 0)
            {
                Die();
            }
        }

        protected abstract void Die();
    }
}
