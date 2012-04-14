namespace DND_Sim
{
    public class Weapon : IWeapon
    {
        private string _Name;
        private int _damageSize;
        private int _damageNum;

        public int DamageSize
        {
            get { return _damageSize; }
            set { _damageSize = value; }
        }

        public int DamageNum
        {
            get { return _damageNum; }
            set { _damageNum = value; }
        } 
        
        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }

        public void fire()
        {
            throw new System.NotImplementedException();
        }

        public void reload()
        {
            throw new System.NotImplementedException();
        }
    }
}