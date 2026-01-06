using UnityEngine;
namespace EarthDefender
{
    public abstract class WeaponStrategy : ScriptableObject
    {
        [SerializeField]
        protected GameObject projectilePrefab;
        [SerializeField]
        protected float projectileSpeed;
        [SerializeField]
        protected float projectileLifeTime;
        [SerializeField]
        protected float fireRate;
        [SerializeField]
        protected int projectileDamadge;

        public int Damadge => projectileDamadge;
        public float FireRate => fireRate;

        public virtual void Initialize() { }
        public abstract void Fire(Transform firePoint, LayerMask layer);
    }
}