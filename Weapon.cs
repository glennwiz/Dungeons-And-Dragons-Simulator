using System;

namespace DND_Sim
{
    public class Weapon : IWeapon
    {
        Random random = new Random();

        public int DamageSize { get; set; }

        public int DamageNum { get; set; }

        public string Name { get; set; }

        public void fire(IActor p, IActor e)
        {
            var total = 0;
            Logger.Log(string.Format("{0} attacks {1}", p.Name, e.Name), ConsoleColor.Magenta);
            for (int i = 0; i < DamageNum; i++)
            {
                
                var dmg = random.Next(1, DamageSize);
                Logger.Log(string.Format("Hit for {0}dmg", dmg), ConsoleColor.DarkRed);
                total += dmg;
                e.Hp -= dmg;
            }
            Logger.Log(string.Format("TotalDamage {0}", total), ConsoleColor.Red); 
            Logger.Log(string.Format("{0} has {1}hp left!\n", e.Name, e.Hp), ConsoleColor.Red);
        }


        public void reload()
        {
            throw new System.NotImplementedException();
        }
    }
}