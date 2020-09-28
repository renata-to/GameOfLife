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
        private FileManager fileManager;
        private ConsoleManager consoleManager = new ConsoleManager();
        private Timer timer;
        public ConsoleKeyInfo cki;
        private GameLogic gameLogic;
        public List<GameLogic> Games = new List<GameLogic>();
        public List<int> GameNumberId = new List<int>();

        public GameManager()
        {
            timer = new Timer(1000);
            timer.AutoReset = true;
            timer.Elapsed += OnTimerElapsed;
            //timer.Enabled = true;
        }

        /// <summary>f
        /// Game initiation menu with options to start new game, start 1000 games, load last game or exit game
        /// </summary>
        /// <returns></returns>
        public void InitiateGame()
        {
            consoleManager.WelcomeToTheGame();
            consoleManager.ShowGameMenu();
            int choise = int.Parse(Console.ReadLine());
            switch (choise)
            {
                case 1:
                    StartGame();
                    break;
                case 2:
                    StartAllGames();
                    break;
                case 3:
                    LoadJSON();
                    break;
                case 4:
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

        /// <summary>
        /// Generates 1000 random boards and adds them to the list
        /// </summary>
        public void StartAllGames()
        {
            Console.Clear();
            int width = CheckUserInput("Please enter board width: ");
            int heigth = CheckUserInput("Please enter board heigth: ");
            GameLogic session = new GameLogic(heigth, width);
            for (int j = 0; j <1000; j++)
            {
                session.GenerateBoard();
                Games.Add(session);
            }

            SelectGames();

        }

        /// <summary>
        /// Adds ucer selected game IDs into GameNumberID ist
        /// </summary>
        public void SelectGames()
        {
            consoleManager.ProposeGames();
            for (int i = 0; i < 8; i++)
            {
                int GameID = CheckUserInput("Please select game you wants to see on the screen: ");
                GameNumberId.Add(GameID);
            }
        }
        

        /// <summary>
        /// Plays all games from the list
        /// </summary>
        public void PlayAllGames()
        {
            foreach(GameLogic game in Games)
            {

            }
        }

        /// <summary>
        /// Prints 8 selected games on console
        /// </summary>
        public void ShowSelectedGames()
        {
            //prints only selected game
        }

        /// <summary>
        /// Shows statistics for alive cells
        /// </summary>
        public void CountTotalNumberOfAliveCells()
        {

        }

        /// <summary>
        /// Cecks if user entered numeric value and if the value is in the range
        /// </summary>
        /// <param name="message">Choise wich console is proposing</param>
        /// <returns></returns>
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
            Games.Add(session);
            StartTimer();
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
        /// Saves the game using JSON
        /// </summary>
        public void SaveJSON()
        {
            //FileManager fileManager = new FileManager();
            //GameLogic gameLogic = new GameLogic(0,0);
            fileManager.SaveGame(gameLogic);
        }

        /// <summary>
        /// Loads the game from the file using JSON
        /// </summary>
        public void LoadJSON()
        {
            fileManager.LoadGame();
        }

        /// <summary>
        /// Starts timer
        /// </summary>
        public void StartTimer()
        {
            timer.Start();
        }

        /// <summary>
        /// Executes game during 1 second
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnTimerElapsed(object sender, ElapsedEventArgs e)
        {
            Games[0].ExecuteOneFullCycle();
            Games[0].PrintNumberOfGeneration();
            Games[0].CountNumberOfAliveCells();
            Games[0].PrintNumberOfAliveCells();
            //SaveJSON();
        }

        /// <summary>
        /// Prints selected games on the console
        /// </summary>
        public void PrintSelectedGames()
        {

        }

    }
}
