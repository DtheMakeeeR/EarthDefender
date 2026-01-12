using UnityEngine;

namespace EarthDefender
{
    public class SplitItem : Item
    {
        protected override void ActiveateItem(Player player)
        {
            player.IncreaseShotsCount((int)amount);
        }
    }
}
