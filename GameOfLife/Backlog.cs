using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace GameOfLife
{
    public class Backlog
    {
        public ConsoleKeyInfo cki;

        
        /// <summary>
        /// Game initiation menu to 
        /// </summary>
        /// <returns></returns>
        public void InitiateGame()
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
        /// Starts game be proposing to enter field sizes
        /// </summary>
        /// <returns></returns>
        public void StartGame()
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
            PlayGame(Heigth,Width);


           /* Game session = new Game(Heigth, Width);
            int gen = 0;
            do
            {
                session.ExecuteFullCycle();
                Console.WriteLine();
                Console.WriteLine("Generation: " + gen++);
                session.CountNumberOfAliveCells();
                session.PrintNumberOfAliveCells();
                Thread.Sleep(1000);
                //while (Console.ReadKey().Key != ConsoleKey.Enter) { } // added to check if neighbour are counting correctly. will be removed.
            } while (!(Console.KeyAvailable && Console.ReadKey(true).Key == ConsoleKey.Escape));        //stops app
           */
            // return session;
        }


        /// <summary>
        /// This method will be used for executing full game cycle
        /// </summary>
        public void PlayGame(int Heigth, int Width)
        {
            Game session = new Game(Heigth,Width);
            int gen = 0;
            do
            {
                session.ExecuteFullCycle();
                Console.WriteLine();
                Console.WriteLine("Generation: " + gen++);
                session.CountNumberOfAliveCells();
                session.PrintNumberOfAliveCells();
                session.SaveGameToFile();
                Thread.Sleep(1000);
                //while (Console.ReadKey().Key != ConsoleKey.Enter) { } // added to check if neighbour are counting correctly. will be removed.
            } while (!(Console.KeyAvailable && Console.ReadKey(true).Key == ConsoleKey.Escape));        //stops app
        }

        public void CheckIfEnteredValueIsNumeric(int value)
        {
            while (!int.TryParse(Console.ReadLine(), out value))
            {
                Console.WriteLine("Entered value is not numeric.");
            }
        }

        public void WelcomeToTheGame()
        {
            Console.WriteLine("<><><><><><><><>><><><>><><>");
            Console.WriteLine("Welcome to Game of Life.");
            Console.WriteLine("<><><><><><><><>><><><>><><>");
            Console.WriteLine();
        }

        public void ShowGameMenu()
        {
            Console.WriteLine("To start a new game please enter 1.");
            Console.WriteLine("To load previous game please enter 2.");
            Console.WriteLine("To exit game please enter 3.");
        }

        public void CheckEnteredNumberRange(int value)
        {
            if (value <= 0 || value > 50)
            {
                Console.WriteLine("Entered number is out of range. Please enter a number from 1 to 50.");
            }
        }

        public Game LoadGame()
        {
            return null;
        }

    }
}
