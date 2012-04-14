namespace DND_Sim
{
    public class Player : IActor
    {  
        private string _name;    //Name of player
        private int _hp;         //HitPoints
        private int _ac;         //ArmourClass
        private int _thac0;      //To Hit Armour Class 0
        private IWeapon _wp;     //Weapon
        private IBuff[] _damageMod;  //Buffs

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

        public int attack(object enemy)
        {
            return 0;
        }
    }
}