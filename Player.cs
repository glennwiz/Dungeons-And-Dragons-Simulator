using System;

namespace DND_Sim
{
    public class Player : IActor
    {
        private Random _random = new Random();

        public string Name { get; set; }

        public int Hp { get; set; }

        public int Ac { get; set; }

        public int Thac0 { get; set; }

        public IWeapon Wp { get; set; }

        public IBuff[] DamageMod { get; set; }

        public int Attack(IActor enemy)
        {
            int random = _random.Next(1, 20);

            if (random >= this.Thac0 - enemy.Ac)
            {
                Logger.Log("Hit", ConsoleColor.Red);
                Wp.fire(this, enemy);
            }
            else
            {
                Logger.Log(string.Format("{0} Miss {1}\n",this.Name,enemy.Name), ConsoleColor.DarkMagenta);
            }

            return 0;
        }
    }
}