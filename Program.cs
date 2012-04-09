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
            MakePlayers();

            Attack();
        }

        private static void Attack()
        {
            throw new NotImplementedException();
        }

        private static void MakePlayers()
        {
            StatNames = new List<string>(new string[]
	        {
	            "HP",
	            "AC",     
	            "thac0",    
	            "dmgnum",
	            "dmgsize",
                "dmgmod"
	        });
            Player = new List<int>(new int[]
            {
                14,
                5,
                18,
                1,
                6,
                0
            });
            Enemy = new List<int>(new int[]
            {
                12,
                7,
                16,
                2,
                4,
                0
            });
        }
    }
}
