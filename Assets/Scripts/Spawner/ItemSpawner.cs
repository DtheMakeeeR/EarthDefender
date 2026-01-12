using MEC;
using System.Collections.Generic;
using UnityEngine;

namespace EarthDefender
{
    public class ItemSpawner : MonoBehaviour
    {
        [SerializeField]
        GameObject enemyPrefab;
        [SerializeField]
        Transform spawnPosition;
        [SerializeField]
        float spawnDelay;
        [SerializeField]
        float randomCoefficient;
        private void Start()
        {
            float randIncrement = spawnDelay * randomCoefficient;
            spawnDelay += Random.Range(-randIncrement, randIncrement);
            Timing.RunCoroutine(_SpawnCoroutine().CancelWith(gameObject));
        }
        private IEnumerator<float> _SpawnCoroutine()
        {
            yield return Timing.WaitForSeconds(spawnDelay);
            Spawn(spawnPosition.position);
        }
        public void Spawn(Vector3 spawnPosition)
        {
            Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
        }
    }
}
