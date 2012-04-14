using System;

namespace DND_Sim
{
    public static class Logger
    {
        public static bool Verblog = true;

        public static void Log(string x, ConsoleColor c)
        {
            if (Verblog)
            {
                Console.ForegroundColor = c;
                Console.WriteLine(x);
            }
        }

        public static void LogTrue(string x, ConsoleColor c)
        {
            Console.ForegroundColor = c;
            Console.WriteLine(x);
        }
    }
}