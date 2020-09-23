using System;

namespace GameOfLife
{
    internal class Program
    {

        private static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            GameManager backlog = new GameManager();
            backlog.InitiateGame();

            Console.ReadLine();
        }
    }
}

