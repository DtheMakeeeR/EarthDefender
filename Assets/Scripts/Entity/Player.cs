using UnityEngine;
using Utilities;

namespace EarthDefender
{
    public class Player : Entity
    {
        [SerializeField]
        Weapon playerWeapon;
        [SerializeField]
        PlayerController playerController;
        protected override void Die()
        {
            Debug.Log("Player Died");
            OnDeath?.Invoke();
        }
        public void IncreaseShotsCount(int amount)
        {
            if(playerWeapon.Strategy is SplitShot splitShot)
            {
                splitShot.ShotsCount += amount;
            }    
        }
        public void AddHealth(int amount)
        {
            Health += amount;
        }
        public void IncreaseSpeed(float amount)
        {
            playerController.IncreaceSpeed(amount);
        }
    }
}
