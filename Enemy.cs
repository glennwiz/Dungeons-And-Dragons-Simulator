using System;

namespace DND_Sim
{
    public class Enemy : Player
    {
        public int attack(Player player)
        {
            var r = new Random(43256);
            var random = r.Next(1, 20);

            if (random >= this.Thac0 - player.Ac)
            {
            }

            return 0;
        }
    }
}