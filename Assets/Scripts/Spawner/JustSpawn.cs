using UnityEngine;
namespace EarthDefender
{
    [CreateAssetMenu(fileName = "JustSpawn", menuName = "EarthDefender/SpawnerStrategy/JustSpawn")]
    public class JustSpawn : SpawnerStrategy
    {
        public override void Spawn(Vector3 spawnPosition)
        {
            Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
        }
    }
}
