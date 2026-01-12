using UnityEngine;

namespace EarthDefender
{
    public class SpeedItem : Item
    {
        protected override void ActiveateItem(Player player)
        {
            player.IncreaseSpeed(amount);
        }
    }
}
