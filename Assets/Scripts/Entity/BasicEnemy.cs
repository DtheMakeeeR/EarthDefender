using System;
using UnityEngine;
namespace EarthDefender
{
    public class BasicEnemy : Entity
    {
        [SerializeField]
        int scoreAmount;
        protected override void Die()
        {
            GameManager.Instance.AddScore(scoreAmount);
            Destroy(gameObject);
        }
    }
}
