using MEC;
using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using Utilities;
namespace EarthDefender
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField]
        GameObject enemyPrefab;
        [SerializeField]
        List<Vector3> spawnPositions;
        [SerializeField]
        float spawnRate;
        [SerializeField]
        float spawnDelay;
        [SerializeField]
        float randomCoefficient;

        [SerializeField]
        int maxSpawn = -1;

        int spawnCounter = 0;

        private void Start()
        {
            float randIncrement = spawnDelay * randomCoefficient;
            spawnDelay += Random.Range(-randIncrement, randIncrement);
            Timing.RunCoroutine(_SpawnCoroutine().CancelWith(gameObject));
        }

        private IEnumerator<float> _SpawnCoroutine()
        {
            yield return Timing.WaitForSeconds(spawnDelay);
            while(spawnCounter != maxSpawn)
            {
                var pos = spawnPositions[UnityEngine.Random.Range(0, spawnPositions.Count)].Add(y: UnityEngine.Random.Range(-0.5f, 0.5f));
                pos += Random.onUnitSphere * randomCoefficient;
                Spawn(pos);
                float randIncrement = spawnRate * randomCoefficient;
                spawnCounter++;
                yield return Timing.WaitForSeconds(spawnRate + UnityEngine.Random.Range(-randIncrement, randIncrement));
            }
        }
        public void Spawn(Vector3 spawnPosition)
        {
            Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
        }
    }
}
