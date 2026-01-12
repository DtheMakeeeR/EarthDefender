using UnityEngine;

namespace EarthDefender
{
    public class HealthItem : Item
    {
        protected override void ActiveateItem(Player player)
        {
            player.AddHealth((int)amount);
        }
    }
}
