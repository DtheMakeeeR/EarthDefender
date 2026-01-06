using UnityEngine;
using System;

namespace EarthDefender
{
    public class Projectile : MonoBehaviour
    {
        [SerializeField] float speed;
        [SerializeField] int damage;
        [SerializeField] AudioSource audioSource;
        [SerializeField] GameObject muzzlePrefab;
        [SerializeField] AudioClip muzzleSound;
        [SerializeField] GameObject hitPrefab;
        [SerializeField] AudioClip hitSound;

        Transform parent;

        public void SetSpeed(float speed) => this.speed = speed;
        public void SetParent(Transform parent) => this.parent = parent;
        public void SetDamage(int damage) => this.damage = damage;

        public Action Callback;

        void Start()
        {
            if (muzzlePrefab != null )
            {
                var muzzleVFX = Instantiate(muzzlePrefab, transform.position, Quaternion.identity);
                muzzleVFX.transform.forward = gameObject.transform.forward;
                muzzleVFX.transform.SetParent(parent);
                DestroyParticleSystem(muzzleVFX);
            }
            if(muzzleSound != null)
            {
                audioSource.clip = muzzleSound;
                audioSource.Play();
            }
        }

        void Update()
        {
            //transform.SetParent(null);
            transform.position += transform.up * (speed * Time.deltaTime);

            Callback?.Invoke();
        }

        void OnCollisionEnter2D(Collision2D collision)
        {
            if (hitPrefab != null)
            {
                ContactPoint2D contact = collision.contacts[0];
                var hitVFX = Instantiate(hitPrefab, contact.point, Quaternion.identity);

                DestroyParticleSystem(hitVFX);
            }
            if (hitSound != null)
            {
                audioSource.clip = hitSound;
                audioSource.Play();
            }
            var entity = collision.gameObject.GetComponent<Entity>();
            entity.TakeDamage(damage);

            Destroy(gameObject);
        }

        void DestroyParticleSystem(GameObject vfx)
        {
            var ps = vfx.GetComponent<ParticleSystem>();
            if (ps == null)
            {
                ps = vfx.GetComponentInChildren<ParticleSystem>();
            }
            Destroy(vfx, ps.main.duration);
        }
    }
}
