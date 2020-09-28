using System;

namespace GameOfLife
{
    internal class Program
    {

        private static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            GameManager backlog = new GameManager();
            backlog.InitiateGame();

            Console.ReadLine();
        }
    }
}

