using System;

namespace DND_Sim
{
    public class Player : IActor
    {  
        private string _name;    //Name of player
        private int _hp;         //HitPoints
        private int _ac;         //ArmourClass 0 is best 20 worst
        private int _thac0;      //To Hit Armour Class 0
        private IWeapon _wp;     //Weapon
        private IBuff[] _damageMod;  //Buffs

        Random _random = new Random(43256);

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public int Hp
        {
            get { return _hp; }
            set { _hp = value; }
        }

        public int Ac
        {
            get { return _ac; }
            set { _ac = value; }
        }

        public int Thac0
        {
            get { return _thac0; }
            set { _thac0 = value; }
        }

        public IWeapon Wp
        {
            get { return _wp; }
            set { _wp = value; }
        }

        public IBuff[] DamageMod1
        {
            get { return _damageMod; }
            set { _damageMod = value; }
        }

        public int attack(Enemy enemy)
        {
            int random = _random.Next(1, 20);

            if (random >= this.Thac0 - enemy.Ac)
            {
                Logger.display("Hit", ConsoleColor.Red);
            }
            else
            {
                Logger.display("Miss", ConsoleColor.Blue);
            }

            return 0;
        }
    }
}