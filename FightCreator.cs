using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DND_Sim
{
    static class BattleCreator
    {
        private static Random rn = new Random();        

        public static void BattleSetup()
        {
            int num_figths;  

            Console.Write("Number of Fights: > ");
             
            var was_number = int.TryParse(Console.ReadLine(), out num_figths);

            if (!was_number)
            {
                Console.WriteLine("Error: Type a number:");
                Console.Write("Number of Fights: > ");
                if (!int.TryParse(Console.ReadLine(), out num_figths))
                {
                    Console.WriteLine("Error: Setting default to 1 match:");
                    num_figths = 1;
                }
            }

            Console.Write("You want Verbose Output? > ");
            string awnser = Console.ReadLine();

            if (awnser[0] == 'y' || awnser[0] == 'Y')
            {
                Logger.Verblog = true;
            }
            else
            {
                Logger.Verblog = false;
            }

            //creating a Archer
            var player1 = new Player { Name = "Archer", Ac = 7, Thac0 = 16, Hp = 12 };
            Logger.LogTrue(string.Format("Player1 created: Name: {0} Armour: {1}, Health Points: {2}", player1.Name, player1.Ac, player1.Hp), ConsoleColor.Green);


            Console.Write("Create random weapon? > ");
            awnser = Console.ReadLine();

            if (awnser[0] == 'y' || awnser[0] == 'Y')
            {
                int DmgNum = rn.Next(1, 3);
                int DmgSize = rn.Next(1, 6);
                var bow = new Bow { Name = string.Format("Bow {0}d{1}",DmgNum,DmgSize), DamageNum = DmgNum, DamageSize = DmgSize };
                player1.Wp = bow;
                Logger.LogTrue(string.Format("{0} equipped\n", bow.Name), ConsoleColor.Cyan);
            }
            else
            {
                var bow = new Bow { Name = "Bow 2d4", DamageNum = 2, DamageSize = 4 };
                player1.Wp = bow;
                Logger.LogTrue(string.Format("{0} equipped\n", bow.Name), ConsoleColor.Cyan);
            }
            //creating a 2d4 bow 
           

            //creating an enemy 
            var enemy = new Enemy { Name = "Wolf", Ac = 6, Hp = 10, Thac0 = 10, Wp = null };
            var claw = new Weapon { Name = "Claw", DamageNum = 1, DamageSize = 6 };
            enemy.Wp = claw;
            Logger.LogTrue(string.Format("{0} with damage {1}d{2} created", enemy.Name, claw.DamageNum, claw.DamageSize), ConsoleColor.Green);

            Console.WriteLine("Press Any Key to start Simulation!!!");
            Console.ReadKey();
            Attack(player1, enemy, num_figths);

            Console.ReadLine();
        }

        private static void Attack(Player p, Enemy e, int num_figths)
        {
            int EnemyWins = 0;
            int PlayerWins = 0;

            for (int i = 0; i < num_figths; i++)
            {
                p.Hp = 12;
                e.Hp = 10;

                Logger.Log("===============================", ConsoleColor.Red);
                Logger.Log(string.Format("Combat number #{0} starts", i + 1), ConsoleColor.White);
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
                if (e.Hp <= 0)
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
                (float)EnemyWins / num_figths * 100), ConsoleColor.Cyan);
        }

    }
}
