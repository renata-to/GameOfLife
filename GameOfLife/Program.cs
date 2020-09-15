using System;

namespace GameOfLife
{
    internal class Program
    {

        private static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Backlog backlog = new Backlog();
            backlog.InitiateGame();

            Console.ReadLine();
        }
    }
}

