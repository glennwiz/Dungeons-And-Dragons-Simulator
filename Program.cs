using System;
using System.Collections.Generic;

namespace DND_Sim
{
    class Program
    {  
        static int num_figths = 50;

        static void Main(string[] args)
        {
            Logger.Verblog = false;

            //creating a Archer
            var player1 = new Player {Name = "Archer", Ac = 7, Thac0 = 16, Hp = 12 };
            Console.WriteLine("Player1 created: Name: {0} Armour: {1}, Health Points: {2}\n", player1.Name, player1.Ac,player1.Hp);
            
            //creating a 2d4 bow 
            var bow = new Bow {Name = "FireBow 2d4",DamageNum = 2, DamageSize = 4};
            player1.Wp = bow;
            Console.WriteLine("{0} equipped\n", bow.Name);

            //creating an enemy 
            var enemy = new Enemy { Name = "Wolf", Ac = 6, Hp = 10, Thac0 = 10, Wp = null};
            var claw = new Weapon { Name = "Claw" , DamageNum = 1, DamageSize = 6};
            enemy.Wp = claw;
            Console.WriteLine("{0} with damage {1}d{2} created\n",enemy.Name, claw.DamageNum,claw.DamageSize);

            Attack(player1,enemy);

            Console.ReadLine();
        }

        private static void Attack(Player p, Enemy e)
        {
            int EnemyWins = 0;
            int PlayerWins = 0;
            
            for (int i = 0; i < num_figths; i++)
            {
                p.Hp = 12;
                e.Hp = 10;

                Logger.Log("===============================", ConsoleColor.Red);
                Logger.Log(string.Format("Combat number #{0} starts", i+1), ConsoleColor.White);
                Logger.Log("===============================", ConsoleColor.Red); 

                while (true)
                {
                    p.Attack(e);
                    if (e.Hp <= 0)
                        break;

                    e.Attack(p);
                    if (p.Hp <= 0)
                        break;

                }

                if (p.Hp <= 0)
                {
                    Logger.Log(string.Format("{0}Died!!!", p.Name), ConsoleColor.Yellow);
                    EnemyWins++;
                }
                if(e.Hp <= 0)
                {
                    Logger.Log(string.Format("{0}Died!!!", e.Name), ConsoleColor.Yellow);
                    PlayerWins++;
                }
            }

            float floatx = float.Parse(PlayerWins.ToString());

            Logger.LogTrue(string.Format("Total Fights {0}, {1} wins {2} - {5}%, {3} wins {4} - {6}%", 
                num_figths, p.Name,
                PlayerWins, e.Name, EnemyWins,
                (float)PlayerWins / num_figths * 100,
                (float)EnemyWins /num_figths *100), ConsoleColor.Cyan);
        }
    }
}
