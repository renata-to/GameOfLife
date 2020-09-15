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
        public Game InitiateGame()
        {
            WelcomeToTheGame();
            ShowGameMenu();
            int choise = int.Parse(Console.ReadLine());
            switch (choise)
            {
                case 1:
                    return StartGame();

                case 2:
                    return LoadGame();

                case 3:
                    return null;
            }
            return null;
        }

        /// <summary>
        /// Starts game be proposing to enter field sizes
        /// </summary>
        /// <returns></returns>
        public Game StartGame()
        {
            Console.Clear();
            Console.Write("Enter board width: ");
            int width;
            while (!int.TryParse(Console.ReadLine(), out width))
            {
                Console.WriteLine("Entered value is not numeric. Please enter number from 1 to 50: ");
            }
            CheckEnteredNumberRange(width);

            Console.Write("Enter board heigth: ");
            int heigth;
            while (!int.TryParse(Console.ReadLine(), out heigth))
            {
                Console.WriteLine("Entered value is not numeric.");
            }
            CheckEnteredNumberRange(heigth);

            Game session = new Game(heigth, width);
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

            return session;
        }
        /// <summary>
        /// This method will be used for executing full game cycle and will be called in the Program.cs
        /// </summary>
        public void PlayGame()
        {

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
