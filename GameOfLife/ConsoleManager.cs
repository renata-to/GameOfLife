using System;
using System.Collections.Generic;
using System.Text;

namespace GameOfLife
{

    /// <summary>
    /// Manages all output/console functions
    /// </summary>
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
            Console.WriteLine();
        }

        /// <summary>
        /// Prints out a board
        /// </summary>
        public void PrintBoard(GameLogic game)
        {
            Console.WriteLine();
            for (int x = 0; x < game.Width; x++)
            {
                for (int y = 0; y < game.Heigth; y++)
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
            Console.WriteLine();
            Console.WriteLine("Please select games you want to see on the screen.");
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
        public PauseMenuSelection ShowPauseMenu()
        {
            Console.Clear();
            Console.WriteLine("1. Continue the game.");
            Console.WriteLine("2. Change games on the board.");
            Console.WriteLine("3. Exit the game.");
            while (true)
            {
                int selection = int.Parse(Console.ReadLine());
                switch (selection)
                {
                    case 1:
                        return PauseMenuSelection.ContinueGame;
                    case 2:
                        return PauseMenuSelection.ChangeGame;
                    case 3:
                        return PauseMenuSelection.ExitGame;
                }
            }
        }

        /// <summary>
        /// Prints error message if selection was not from the list
        /// </summary>
        public void PrintPauseErrorMessage()
        {
            Console.WriteLine("Please select action from the list.");
        }

        /// <summary>
        /// Cleans console
        /// </summary>
        public void CleanConsole()
        {
            Console.Clear();
        }

        /// <summary>
        /// prints total number of alive cells
        /// </summary>
        /// <param name="totalAliveCells">total number of alive cells</param>
        public void ShowNumberOfTotalAliveCells(int totalAliveCells)
        {
            Console.WriteLine("Total number of alive cells: {0}", totalAliveCells);
        }

        /// <summary>
        /// prints number of active games
        /// </summary>
        /// <param name="activeGameAmount">total number of active games</param>
        public void ShowActiveGameNumber(int activeGameAmount)
        {
            Console.WriteLine("Total number of active games: {0}", activeGameAmount);
        }

        /// <summary>
        /// Prints error message for number of selected visible games
        /// </summary>
        public void PrintViewInputErrorMessage()
        {
            Console.WriteLine("Please enter the number that is less then selected game amount.");
        }

    }
}
