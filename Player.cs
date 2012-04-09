namespace DND_Sim
{
    public class Player : IActor
    {
        private string name;
        private int HP;         //HitPoints
        private int AC;         //ArmourClass
        private int THAC0;      //To Hit Armour Class 0
        private IWeapon WP;     //Weapon
        private IBuff[] DamageMod;  //Buffs

        public int attack(object enemy)
        {
            return 0;
        }
    }
}