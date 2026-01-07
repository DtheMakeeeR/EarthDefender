using UnityEngine;
namespace EarthDefender
{
    [CreateAssetMenu(fileName = "JustSpawn", menuName = "EarthDefender/SpawnerStrategy/JustSpawn")]
    public class JustSpawn : SpawnerStrategy
    {
        public override void Spawn()
        {
            foreach (var pos in spawnPosition)
            {
                Instantiate(enemyPrefab, pos, Quaternion.identity);
            }
        }
    }
}
