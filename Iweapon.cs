namespace DND_Sim
{
    public interface IWeapon
    {
        int DamageSize { get; set; }

        int DamageNum { get; set; }

        string Name { get; set; }

        void fire(IActor p , IActor e);
        void reload(); 
    }
}