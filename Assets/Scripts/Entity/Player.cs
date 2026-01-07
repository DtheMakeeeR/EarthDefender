using UnityEngine;
using Utilities;

namespace EarthDefender
{
    public class Player : Entity
    {
        protected override void Die()
        {
            Debug.Log("Player Died");
            Helpers.QuitGame();
        }
    }
}
