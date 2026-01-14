using UnityEngine;
using UnityEngine.UI;
namespace EarthDefender
{
    public class Boss : BasicEnemy
    {
        [SerializeField]
        Image bossHealthBar;

        public bool IsInvinsible = true;
        public override void TakeDamage(int amount)
        {
            if(!IsInvinsible)
            {
                base.TakeDamage(amount);
                bossHealthBar.fillAmount = HealthNormalized;
            }
        }
    }
}
