using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;

namespace GameOfLife
{
    public class Backlog
    {
        public ConsoleKeyInfo cki;


        /// <summary>
        /// Game initiation menu to 
        /// </summary>
        /// <returns></returns>
        public async void InitiateGame()
        {
            WelcomeToTheGame();
            ShowGameMenu();
            int choise = int.Parse(Console.ReadLine());
            switch (choise)
            {
                case 1:
                    StartGame();
                    break;
                case 2:
                    LoadGame();
                    break;
                case 3:
                    break;
            }
        }

        /// <summary>
        /// Starts game by proposing to enter field sizes
        /// </summary>
        public async void StartGame()
        {
            Console.Clear();
            Console.Write("Enter board width: ");
            int Width;
            while (!int.TryParse(Console.ReadLine(), out Width))
            {
                Console.WriteLine("Entered value is not numeric. Please enter number from 1 to 50: ");
            }
            CheckEnteredNumberRange(Width);

            Console.Write("Enter board heigth: ");
            int Heigth;
            while (!int.TryParse(Console.ReadLine(), out Heigth))
            {
                Console.WriteLine("Entered value is not numeric.");
            }
            CheckEnteredNumberRange(Heigth);

            PlayGame(Heigth, Width);

        }

        /// <summary>
        /// This method will be used for executing full game cycle
        /// </summary>
        public async void PlayGame(int Heigth, int Width)
        {
            Game session = new Game(Heigth, Width);
            int gen = 0;
            do
            {
                session.ExecuteFullCycle();
                Console.WriteLine();
                Console.WriteLine("Generation: " + gen++);
                session.CountNumberOfAliveCells();
                session.PrintNumberOfAliveCells();
                session.SaveGameToFile();
                await Task.Delay(1000);
            } while (!(Console.KeyAvailable && Console.ReadKey(true).Key == ConsoleKey.Escape));
        }

        public void CheckIfEnteredValueIsNumeric(int value)
        {
            while (!int.TryParse(Console.ReadLine(), out value))
            {
                Console.WriteLine("Entered value is not numeric.");
            }
        }

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
        /// Checks if entered number is in the range
        /// </summary>
        /// <param name="value"></param>
        public void CheckEnteredNumberRange(int value)
        {
            if (value <= 0 || value > 50)
            {
                Console.WriteLine("Entered number is out of range. Please enter a number from 1 to 50.");
            }
        }

        /// <summary>
        /// Wiil be used to load game from the file
        /// </summary>
        /// <returns></returns>
        public Game LoadGame()
        {
            return null;
        }
    }
}
