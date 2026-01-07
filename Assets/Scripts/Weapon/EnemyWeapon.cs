namespace EarthDefender
{
    public class EnemyWeapon : Weapon
    {
        private void Update()
        {
            if (isReloaded) Fire();
        }
    }
}
