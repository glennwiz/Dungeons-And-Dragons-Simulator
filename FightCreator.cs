using System;

namespace DND_Sim
{
    static class BattleCreator
    {
        private static Random random = new Random();

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

            Console.Write("You want Verbose Output? Y/N > ");
            string answer = Console.ReadLine();

            if (answer[0].ToString().ToUpper() == "Y")
            {
                Logger.Verblog = true;
            }
            else
            {
                Logger.Verblog = false;
            }

            //creating a Archer
            var player1 = new Player { Name = "Archer", ArmourClass = 7, Thac0 = 16, Hp = 12 };
            Logger.LogTrue(string.Format("Player1 created: Name: {0} Armour: {1}, Health Points: {2}", player1.Name, player1.ArmourClass, player1.Hp), ConsoleColor.Green);

            //creating a Mage
            var player2 = new Player { Name = "Mage", ArmourClass = 7, Thac0 = 16, Hp = 10 };
            Logger.LogTrue(string.Format("Player2 created: Name: {0} Armour: {1}, Health Points: {2}", player2.Name, player2.ArmourClass, player2.Hp), ConsoleColor.Green);

            Console.Write("Create random weapon? > Y/N");
            answer = Console.ReadLine();

            if (answer[0].ToString().ToUpper() == "Y")
            {
                int DmgNum = random.Next(1, 3);
                int DmgSize = random.Next(1, 6);
                var bow = new Bow { Name = string.Format("Bow {0}d{1}", DmgNum, DmgSize), DamageNum = DmgNum, DamageSize = DmgSize };
                player1.Weapon = bow;
                Logger.LogTrue(string.Format("{0} equipped\n", bow.Name), ConsoleColor.Cyan);
            }
            else
            {
                //creating a 2d4 bow
                var bow = new Bow { Name = "Bow 2d4", DamageNum = 2, DamageSize = 4 };
                player1.Weapon = bow;
                Logger.LogTrue(string.Format("{0} equipped\n", bow.Name), ConsoleColor.Cyan);
            }

            //creating an enemy 
            var enemy = new Enemy { Name = "Wolf", ArmourClass = 6, Hp = 10, Thac0 = 10, Weapon = null };
            var claw = new Weapon { Name = "Claw", DamageNum = 1, DamageSize = 6 };
            enemy.Weapon = claw;
            Logger.LogTrue(string.Format("{0} with damage {1}d{2} created", enemy.Name, claw.DamageNum, claw.DamageSize), ConsoleColor.Green);

            //create a Orc
            var orc = new Enemy { Name = "Orc", ArmourClass = 6, Hp = 10, Thac0 = 10, Weapon = null };
            var axe = new Weapon { Name = "Axe", DamageNum = 1, DamageSize = 8 };
            orc.Weapon = axe;
            Logger.LogTrue(string.Format("{0} with damage {1}d{2} created", orc.Name, axe.DamageNum, axe.DamageSize), ConsoleColor.Green);
            
            Console.WriteLine("Press Any Key to start Simulation!!!");
            Console.ReadKey();
            Attack(player1, enemy, num_figths);

            Console.ReadLine();
        }

        private static void Attack(Player player, Enemy enemy, int num_figths)
        {
            int EnemyWins = 0;
            int PlayerWins = 0;

            for (int i = 0; i < num_figths; i++)
            {
                player.Hp = 12;
                enemy.Hp = 10;

                Logger.Log("===============================", ConsoleColor.Red);
                Logger.Log(string.Format("Combat number #{0} starts", i + 1), ConsoleColor.White);
                Logger.Log("===============================", ConsoleColor.Red);

                while (true)
                {
                    player.Attack(enemy);
                    if (enemy.Hp <= 0)
                        break;

                    enemy.Attack(player);
                    if (player.Hp <= 0)
                        break;
                }

                if (player.Hp <= 0)
                {
                    Logger.Log(string.Format("{0}Died!!!", player.Name), ConsoleColor.Yellow);
                    EnemyWins++;
                }
                if (enemy.Hp <= 0)
                {
                    Logger.Log(string.Format("{0}Died!!!", enemy.Name), ConsoleColor.Yellow);
                    PlayerWins++;
                }
            }

            float floatx = float.Parse(PlayerWins.ToString());

            Logger.LogTrue(string.Format("Total Fights {0}, {1} wins {2} - {5}%, {3} wins {4} - {6}%",
                num_figths, player.Name,
                PlayerWins, enemy.Name, EnemyWins,
                (float)PlayerWins / num_figths * 100,
                (float)EnemyWins / num_figths * 100), ConsoleColor.Cyan);
        }

    }
}
