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

        private void Start() => Timing.RunCoroutine(_SpawnCoroutine().CancelWith(gameObject));

        private IEnumerator<float> _SpawnCoroutine()
        {
            while(true)
            {
                spawnerStrategy.Spawn();
                yield return Timing.WaitForSeconds(spawnerStrategy.SpawnRate);
            }
        }
    }
}
