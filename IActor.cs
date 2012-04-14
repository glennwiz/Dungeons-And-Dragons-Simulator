namespace DND_Sim
{
    public interface IActor
    {
        string Name { get; set; }

        int Hp { get; set; }

        int Ac { get; set; }

        int Thac0 { get; set; }

        IWeapon Wp
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