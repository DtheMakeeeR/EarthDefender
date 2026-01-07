using UnityEngine;
using Utilities;
using System.Collections.Generic;
using MEC;
namespace EarthDefender
{
    public class Weapon : MonoBehaviour
    {
        [SerializeField]
        protected Transform firePoint;
        [SerializeField]
        protected WeaponStrategy weaponStrategy;
        [SerializeField, Layer]
        protected int layer;

        public WeaponStrategy Strategy => weaponStrategy;

        protected bool isReloaded = true;
        void OnValidate() => layer = gameObject.layer;

        void Start() => weaponStrategy.Initialize();
        public void Fire()
        {
            if (isReloaded)
            {
                weaponStrategy.Fire(firePoint, layer);
                isReloaded = false;
                Timing.RunCoroutine(_ReloadCoroutine().CancelWith(gameObject));
            }
        }
        protected virtual IEnumerator<float> _ReloadCoroutine()
        {
            yield return Timing.WaitForSeconds(weaponStrategy.FireRate);
            isReloaded = true;
        }
    }
}
