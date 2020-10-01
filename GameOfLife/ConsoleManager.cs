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
            Console.WriteLine("To start 1000 games please enter 2.");
            Console.WriteLine("To load previous game please enter 3.");
            Console.WriteLine("To exit game please enter 4.");
            Console.WriteLine();
        }

        /// <summary>
        /// Prints out a board
        /// </summary>
        public void PrintBoard(GameLogic game)
        {
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

        /// <summary>
        /// Proposes to select eight game that will be visible in the console
        /// </summary>
        public void ProposeGames()
        {
            Console.WriteLine("Please select 8 games you want to see on the screen.");
        }


        /// <summary>
        /// Prints each of 8 selected games with it's alive cell number, generation number and Game ID
        /// </summary>
        /// <param name="Games">List with random generated games</param>
        /// <param name="GameNumberId">List with user game selection</param>
        public void PrintSelectedGames(List<GameLogic> Games, List<int> GameNumberId)
        {
            foreach (int index in GameNumberId)
            {
                Console.WriteLine("Game #{0}:", index);
                GameLogic game = Games[index - 1];
                PrintBoard(game);
                game.PrintNumberOfGeneration();
                game.CountNumberOfAliveCells();
                game.PrintNumberOfAliveCells();
                Console.WriteLine();

            }

        }

        /// <summary>
        /// Shows pause menu with selections
        /// </summary>
        public void ShowPauseMenu()
        {
            Console.Clear();
            Console.WriteLine("1. Continue the game.");
            Console.WriteLine("2. Change games on the board.");
            Console.WriteLine("3. Exit the game.");
        }

    }
}
