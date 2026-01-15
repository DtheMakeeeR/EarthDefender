using UnityEngine;
using Utilities;
namespace EarthDefender
{
    [CreateAssetMenu(menuName = "EarthDefender/WeaponStrategy/TrackingShot", fileName = "TrackingShot")]
    public class TrackingShot : WeaponStrategy
    {
        [SerializeField]
        float trackSpeed = 1f;
        [SerializeField]
        float projectileMaxSpeed;
        [SerializeField]
        float smooth;
        Transform target;
        
        public override void Initialize()
        {
            target = GameManager.Instance.Player.transform;
        }
        public override void Fire(Transform firePoint, LayerMask layer)
        {
            var projectile = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);

            projectile.layer = (int)layer;

            var projectileComponent = projectile.GetComponent<Projectile>();

            projectileComponent.SetParent(firePoint);
            projectileComponent.SetSpeed(projectileMaxSpeed);
            projectileComponent.SetDamage(projectileDamadge);

            projectileComponent.Callback += () => 
            {
                Vector3 direction = (target.position - projectile.transform.position).With(z: 0).normalized;

                Quaternion targetRotation = Quaternion.LookRotation(Vector3.forward, direction);

                projectile.transform.rotation = Quaternion.Slerp(
                    projectile.transform.rotation,
                    targetRotation,
                    trackSpeed * Time.deltaTime
                );
                var speed = Mathf.Lerp(projectileComponent.GetSpeed(), projectileSpeed, Time.deltaTime * smooth);
                projectileComponent.SetSpeed(speed);
            };

            Destroy(projectile, projectileLifeTime);
        }
    }
}