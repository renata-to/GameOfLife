using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Timers;
using GameOfLife;

namespace GameOfLife
{
    public class GameManager
    {
        private Timer timer;
        public ConsoleKeyInfo cki;
        private FileManager fileManager;
        private GameLogic gameLogic;

        
        /*public GameManager()
        {
            timer = new Timer(1000);
            timer.AutoReset = true;
            timer.Elapsed += OnTimerElapsed;
            timer.Enabled = true;
        }*/

        /// <summary>f
        /// Game initiation menu to 
        /// </summary>
        /// <returns></returns>
        public void InitiateGame()
        {
            ConsoleManager console = new ConsoleManager();
            console.WelcomeToTheGame();
            console.ShowGameMenu();
            int choise = int.Parse(Console.ReadLine());
            switch (choise)
            {
                case 1:
                    StartGame();
                    break;
                case 2:
                    LoadJSON();
                    break;
                case 3:
                    break;
            }
        }

        /// <summary>
        /// Starts game by proposing to enter field sizes
        /// </summary>
        public void StartGame()
        {
            Console.Clear();
            int Width = CheckUserInput("Please enter board width: ");
            int Heigth = CheckUserInput("Please enter board heigth: ");
          
            PlayGame(Heigth, Width);

        }

        private int CheckUserInput(string message)
        {
            while (true)
            {
                Console.Write(message);
                int input = int.Parse(Console.ReadLine());

                if (input <= 0 || input > 50)
                {
                    Console.WriteLine("Please enter the number from 1 to 50");
                }
                else
                {
                    return input;
                }

            }
        }

        /// <summary>
        /// This method will be used for executing full game cycle
        /// </summary>
        public void PlayGame(int Heigth, int Width)
        {
            GameLogic session = new GameLogic(Heigth, Width);

            do
            {
                session.ExecuteFullCycle();
                session.PrintNumberOfGeneration();
                session.CountNumberOfAliveCells();
                session.PrintNumberOfAliveCells();
                System.Threading.Thread.Sleep(1000);
                //session.SaveGameToFile();
                //SaveJSON();
            } while (!(Console.KeyAvailable && Console.ReadKey(true).Key == ConsoleKey.Escape));
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
        /// Loads game from the file using Stream.Reader
        /// </summary>
        /// <returns></returns>
        public GameLogic LoadGame()
        {
            GameLogic game = new GameLogic(0,0);
            game.LoadGame();
            return game;
        }

        /// <summary>
        /// Used for saving the game using JSON
        /// </summary>
        public void SaveJSON()
        {
            FileManager fileManager = new FileManager(@"C: \Users\renate.tomilova\Desktop\Sample.txt");
            fileManager.SaveGame(gameLogic);
        }

        public void LoadJSON()
        {
            fileManager.LoadGame();
        }

        public void StartTimer()
        {
            timer.Start();
        }

        private void OnTimerElapsed(object sender, ElapsedEventArgs e)
        {
            GameLogic game = new GameLogic(0,0);
            game.ExecuteFullCycle();
        }

    }
}
