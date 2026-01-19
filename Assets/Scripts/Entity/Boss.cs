using UnityEngine;
using UnityEngine.UI;
namespace EarthDefender
{
    public class Boss : BasicEnemy
    {
        [SerializeField]
        Image bossHealthBar;
        [SerializeField]
        EnemyWeapon[] bossWeapons;
        public bool IsInvinsible = true;

        private void Awake()
        {
            SetWeaponsActive(false);
        }


        public override void TakeDamage(int amount)
        {
            if(!IsInvinsible)
            {
                base.TakeDamage(amount);
                bossHealthBar.fillAmount = HealthNormalized;
            }
        }

        public void SetWeaponsActive(bool val)
        {
            foreach (var weapon in bossWeapons)
            {
                weapon.enabled = val;
            }
        }
    }
}
