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
        private FileManager fileManager = new FileManager(@"C:\Users\renate.tomilova\Desktop\Sample.txt");
        private ConsoleManager consoleManager = new ConsoleManager();
        private readonly Timer timer;
        public List<GameLogic> Games = new List<GameLogic>();
        private List<int> GameNumberId = new List<int>();
        private int choise;
        public int totalAliveCells;
        private int gameAmount;
        private int visibleGames;


        public GameManager()
        {
            timer = new Timer(1000);
            timer.AutoReset = true;
            timer.Elapsed += OnTimerElapsed;
            timer.Enabled = false;
        }

        /// <summary>f
        /// Game initiation menu with options to start new game, start 1000 games, load last game or exit game
        /// </summary>
        /// <returns></returns>
        public void InitiateGame()
        {
            consoleManager.WelcomeToTheGame();
            consoleManager.ShowGameMenu();
            choise = int.Parse(Console.ReadLine());
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
        private void StartGame()
        {
            Console.Clear();
            gameAmount = CheckGameInput("How many games do you want to play?");
            visibleGames = CheckViewInput("How many games do you want to see on the screen?");
            int width = CheckUserInput("Please enter board width: ");
            int heigth = CheckUserInput("Please enter board heigth: ");

            for (int j = 0; j < gameAmount; j++)
            {
                GameLogic game = new GameLogic(width, heigth);
                game.GenerateBoard();
                Games.Add(game);
            }

            CheckGameAmount();
            PlayGame();

        }

        /// <summary>
        /// Adds ucer selected game IDs into GameNumberID ist
        /// </summary>
        private void SelectGames()
        {
            consoleManager.ProposeGames();
            for (int i = 0; i < visibleGames; i++)
            {
                int GameID = CheckGameInput("Please select game # you want to see on the screen: ");
                GameNumberId.Add(GameID);
            }

        }

        /// <summary>
        /// If game amount is > 1 Console proposes to select games 
        /// </summary>
        private void CheckGameAmount()
        {
            if (gameAmount > 1)
            {
                SelectGames();
            }
        }

        /// <summary>
        /// This method will be used for executing full game cycle
        /// </summary>
        private void PlayGame()
        {
            Console.CancelKeyPress += new ConsoleCancelEventHandler(myHandler);
            while (true)
            {
                StartTimer();
            }

        }

        /// <summary>
        /// responsible for actions when game is paused
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void myHandler(object sender, ConsoleCancelEventArgs args)
        {
            args.Cancel = true;
            timer.Enabled = false;
            timer.Elapsed -= OnTimerElapsed;
            Pause();
        }

        /// <summary>
        /// Prints 8 selected games on console
        /// </summary>
        private void ShowSelectedGames()
        {
            Console.Clear();
            consoleManager.PrintSelectedGames(Games, GameNumberId);
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
        /// checks if userinput is numeric and within the range
        /// </summary>
        /// <param name="message">game selection for input</param>
        /// <returns></returns>
        private int CheckGameInput(string message)
        {
            while (true)
            {
                Console.Write(message);
                int input = int.Parse(Console.ReadLine());

                if (input <= 0 || input > 1000)
                {
                    Console.WriteLine("Please enter the number from 1 to 1000");
                }
                else
                {
                    return input;
                }

            }
        }

        /// <summary>
        /// Checks if number of visible games is less then total game amount
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        private int CheckViewInput(string message)
        {
            while (true)
            {
                Console.Write(message);
                int input = int.Parse(Console.ReadLine());

                if (input <= 0 || input > gameAmount)
                {
                    Console.WriteLine("Please enter the number that is less then selected game amount.");
                }
                else
                {
                    return input;
                }

            }
        }

        /// <summary>
        /// Saves the game using JSON
        /// </summary>
        private void SaveJSON()
        {
            fileManager.SaveGame(Games);
        }

        /// <summary>
        /// Loads the game from the file using JSON
        /// </summary>
        private void LoadJSON()
        {
            Games = fileManager.LoadGame();

        }

        /// <summary>
        /// Starts timer
        /// </summary>
        private void StartTimer()
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

            try
            {
                if (gameAmount > 1)
                {
                    Console.Clear();
                    totalAliveCells = 0;
                    foreach (var game in Games)
                    {
                        totalAliveCells += game.aliveCells;

                        game.CreateNextGeneration();
                        game.SwitchArrays();
                        game.CountNumberOfAliveCells();
                    }
                    ShowSelectedGames();
                    Console.WriteLine("Total number of alive cells: {0}", totalAliveCells);
                    SaveJSON();

                }

                else if (gameAmount == 1)
                {
                    Console.Clear();
                    Games[0].ExecuteOneFullCycle();
                    Games[0].PrintNumberOfGeneration();
                    Games[0].CountNumberOfAliveCells();
                    Games[0].PrintNumberOfAliveCells();
                    SaveJSON();
                }
            }

            catch (Exception b)
            {
                Console.WriteLine(b.Message);
            }

        }

        /// <summary>
        /// Pauses the game and proposes to continue, change games on console, or exit.
        /// </summary>
        private void Pause()
        {
            consoleManager.ShowPauseMenu();

                int selection = int.Parse(Console.ReadLine());

                switch (selection)
                {
                    case 1:
                    break;
                    case 2:
                        SelectGames();
                        break;
                    case 3:
                        break;
                    default:
                        Console.WriteLine("Please select action from the list.");
                        break;
                }
            timer.Elapsed += OnTimerElapsed;

        }


    }
}
