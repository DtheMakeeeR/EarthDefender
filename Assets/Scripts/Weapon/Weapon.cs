using UnityEngine;
using Utilities;

namespace EarthDefender
{
    public class Weapon : MonoBehaviour
    {
        [SerializeField]
        Transform firePoint;
        [SerializeField]
        WeaponStrategy weaponStrategy;
        [SerializeField, Layer]
        protected int layer;


        float fireTimer;
        void OnValidate() => layer = gameObject.layer;

        void Start() => weaponStrategy.Initialize();
        public void Fire()
        {
            if (fireTimer >= weaponStrategy.FireRate)
            {
                weaponStrategy.Fire(firePoint, layer);
                fireTimer = 0f;
            }
        }
        private void Update()
        {
            fireTimer += Time.deltaTime;
        }
    }
}
