namespace EarthDefender
{
    public class BasicEnemy : Entity
    {
        protected override void Die()
        {
            Destroy(gameObject);
        }
    }
}
