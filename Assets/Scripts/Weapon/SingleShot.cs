using UnityEngine;
namespace EarthDefender
{
    [CreateAssetMenu(menuName = "EarthDefender/WeaponStrategy/SingleShot", fileName = "SingleShot")]
    public class SingleShot : WeaponStrategy
    {
        public override void Fire(Transform firePoint, LayerMask layer)
        {
            var projectile = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);

            projectile.layer = (int)layer;

            var projectileComponent = projectile.GetComponent<Projectile>();

            projectileComponent.SetParent(firePoint);
            projectileComponent.SetSpeed(projectileSpeed);
            projectileComponent.SetDamage(projectileDamadge);

            Destroy(projectile, projectileLifeTime);
        }
    }
}