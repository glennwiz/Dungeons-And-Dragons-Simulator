using System;

namespace DND_Sim
{
    public static class Logger
    {
        public static bool verbose = true;

        public static void display(string x, ConsoleColor c)
        {
            if (verbose)
            {
                Console.ForegroundColor = c;
                Console.WriteLine(x);
            }
        }
    }
}