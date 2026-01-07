using MEC;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using UnityEngine;
using Utilities;
namespace EarthDefender
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField]
        SpawnerStrategy spawnerStrategy;
        [SerializeField]
        List<Vector3> spawnPositions;

        private void Start() => Timing.RunCoroutine(_SpawnCoroutine().CancelWith(gameObject));

        private IEnumerator<float> _SpawnCoroutine()
        {
            while(true)
            {
                var pos = spawnPositions[UnityEngine.Random.Range(0, spawnPositions.Count)].Add(y: UnityEngine.Random.Range(-0.5f, 0.5f));
                spawnerStrategy.Spawn(pos);
                yield return Timing.WaitForSeconds(spawnerStrategy.SpawnRate + UnityEngine.Random.Range(-0.5f, 0.5f));
            }
        }
    }
}
