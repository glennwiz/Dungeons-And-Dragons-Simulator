using System;
using System.Collections.Generic;

namespace DND_Sim
{
    class Program
    {  
        int num_figths = 1;

        static List<string> StatNames;

        static List<int> Player;

        static List<int> Enemy;


        static void Main(string[] args)
        {
            //creating a Archer
            Player player1 = new Player {Name = "Archer", Ac = 7, Thac0 = 16, Hp = 12 };
            Console.WriteLine("Player1 created: Name: {0} Armour: {1}, Health Points: {2}", player1.Name, player1.Ac,player1.Hp);
            
            //creating a 2d4 bow 
            Bow bow = new Bow {Name = "FireBow 2d4",DamageNum = 2, DamageSize = 4};
            player1.Wp = bow;
            Console.WriteLine("{0} equipped ", bow.Name);

            //creating an enemy 
            Enemy Enemy = new Enemy { Name = "Wolf", Ac = 2, Hp = 10, Thac0 = 10, Wp = null};
            Weapon Claw = new Weapon { Name = "Claw" , DamageNum = 1, DamageSize = 6};
            Enemy.Wp = Claw;
            Console.WriteLine("{0} with damage {1}d{2} created",Enemy.Name, Claw.DamageNum,Claw.DamageSize);

            Console.ReadLine();
        }

        private static void Attack()
        {
            throw new NotImplementedException();
        }
    }
}
