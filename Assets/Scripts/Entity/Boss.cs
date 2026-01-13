using UnityEngine;
using UnityEngine.UI;
namespace EarthDefender
{
    public class Boss : BasicEnemy
    {
        [SerializeField]
        Image bossHealthBar;

        public override void TakeDamage(int amount)
        {
            base.TakeDamage(amount);
            bossHealthBar.fillAmount = HealthNormalized;
        }
    }
}
