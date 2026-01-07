using UnityEngine;
namespace EarthDefender
{
    [CreateAssetMenu(menuName = "EarthDefender/WeaponStrategy/SplitShot", fileName = "SplitShot")]
    public class SplitShot : WeaponStrategy
    {
        [SerializeField]
        int shotsCount = 1;
        [SerializeField]
        float spreadAngle = 7f;
        public int ShotsCount
        {
            get => shotsCount;
            set
            {
                shotsCount = value;
                if (shotsCount < 1) shotsCount = 1;
                while (shotsCount/2 * spreadAngle > 9)
                {
                    spreadAngle--;
                }
            }
        }
        public override void Fire(Transform firePoint, LayerMask layer)
        {
            
            for(int i = 0; i < shotsCount/2; i++)
            {
                GameObject projectileRight = MakeProjectile(firePoint, layer);
                projectileRight.transform.Rotate(0f, 0f, spreadAngle * (i + 1));
                Destroy(projectileRight, projectileLifeTime);

                GameObject projectileLeft = MakeProjectile(firePoint, layer);
                projectileLeft.transform.Rotate(0f, 0f, spreadAngle * (-i - 1));
                Destroy(projectileLeft, projectileLifeTime);
            }

            if(shotsCount % 2 == 1)
            {
                GameObject midProjectile = MakeProjectile(firePoint, layer);
                Destroy(midProjectile, projectileLifeTime);
            }           

        }

        private GameObject MakeProjectile(Transform firePoint, LayerMask layer)
        {
            var projectile = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
            projectile.transform.SetParent(firePoint);
            projectile.layer = (int)layer;
            var projectileComponent = projectile.GetComponent<Projectile>();

            projectileComponent.SetParent(firePoint);
            projectileComponent.SetSpeed(projectileSpeed);
            projectileComponent.SetDamage(projectileDamadge);
            return projectile;
        }
    }
}