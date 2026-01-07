using UnityEngine;
using System.Collections.Generic;
namespace EarthDefender
{
    public abstract class SpawnerStrategy : ScriptableObject
    {
        [SerializeField]
        protected GameObject enemyPrefab;
        [SerializeField]
        protected float spawnRate;

        public float SpawnRate => spawnRate;

        public abstract void Spawn(Vector3 spawnPosition);
    }
}
