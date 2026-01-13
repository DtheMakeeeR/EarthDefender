using UnityEngine;

namespace EarthDefender
{
    public class BossPart : BasicEnemy
    {
        [SerializeField]
        Boss boss;

        public override void TakeDamage(int amount)
        {
            base.TakeDamage(amount);
            boss.TakeDamage(amount);
        }
    }
}
