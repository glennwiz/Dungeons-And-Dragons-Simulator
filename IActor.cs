namespace DND_Sim
{
    public interface IActor
    {
        string Name { get; set; }

        int Hp { get; set; }

        int ArmourClass { get; set; }

        int Thac0 { get; set; }

        IWeapon Weapon
        {
            get;
            set;
        }

        IBuff[] DamageMod
        {
            get;
            set;
        }
    }
}