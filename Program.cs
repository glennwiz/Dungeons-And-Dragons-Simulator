using System;
using System.Collections.Generic;

namespace DND_Sim
{
    class Program
    {  
        static int num_figths = 1;


        static void Main(string[] args)
        {
            //creating a Archer
            var player1 = new Player {Name = "Archer", Ac = 7, Thac0 = 16, Hp = 12 };
            Console.WriteLine("Player1 created: Name: {0} Armour: {1}, Health Points: {2}\n", player1.Name, player1.Ac,player1.Hp);
            
            //creating a 2d4 bow 
            var bow = new Bow {Name = "FireBow 2d4",DamageNum = 2, DamageSize = 4};
            player1.Wp = bow;
            Console.WriteLine("{0} equipped\n", bow.Name);

            //creating an enemy 
            var enemy = new Enemy { Name = "Wolf", Ac = 2, Hp = 10, Thac0 = 10, Wp = null};
            var claw = new Weapon { Name = "Claw" , DamageNum = 1, DamageSize = 6};
            enemy.Wp = claw;
            Console.WriteLine("{0} with damage {1}d{2} created\n",enemy.Name, claw.DamageNum,claw.DamageSize);

            Attack(player1,enemy);

            Console.ReadLine();
        }

        private static void Attack(Player p, Enemy e)
        {
            var r = new Random(24235);

            for (int i = 0; i < num_figths; i++)
            {
                Logger.display("===============================", ConsoleColor.Red);
                Logger.display(string.Format("Combat number #{0} starts", i+1), ConsoleColor.White);
                Logger.display("===============================", ConsoleColor.Red); 
                
                var randomValue = r.Next(0, 100);

                while (true)
                {
                    if (p.Hp <= 0)
                        break;

                    if (randomValue >= 50)
                    {
                        p.attack(e);
                    }
                    else
                    {
                        e.attack(p);
                    }
                }
                
            }
           
        }
    }
}
