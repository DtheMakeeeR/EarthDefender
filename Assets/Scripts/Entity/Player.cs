using UnityEngine;

namespace EarthDefender
{
    public class Player : Entity
    {
        protected override void Die()
        {
            Debug.Log("Player Died");
        }
    }
}
