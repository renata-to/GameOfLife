using System;
using System.Collections.Generic;
using System.Text;

namespace GameOfLife
{
    public class ConsoleManager
    {
        /// <summary>
        /// Prints out welcome message
        /// </summary>
        public void WelcomeToTheGame()
        {
            Console.WriteLine("<><><><><><><><>><><><>><><>");
            Console.WriteLine("Welcome to Game of Life.");
            Console.WriteLine("<><><><><><><><>><><><>><><>");
            Console.WriteLine();
        }

        /// <summary>
        /// Shows main menu to select from start, load, exit.
        /// </summary>
        public void ShowGameMenu()
        {
            Console.WriteLine("To start a new game please enter 1.");
            Console.WriteLine("To load previous game please enter 2.");
            Console.WriteLine("To exit game please enter 3.");
        }

        /// <summary>
        /// Prints out a board
        /// </summary>
        public void PrintBoard(GameLogic game)
        {
            Console.Clear();
            Console.WriteLine();
            for (int x = 0; x < game.width; x++)
            {
                for (int y = 0; y < game.heigth; y++)
                {
                    Console.Write(game.NowGeneration[x, y] ? "O" : " ");
                }
                Console.WriteLine();
            }
            //Console.SetCursorPosition(0, Console.WindowTop);
        }
    }
}
