using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using GameOfLife;
using System.Timers;

namespace GameOfLife
{
    public class GameLogic
    {
        public int heigth { get; private set; }
        public int width { get; private set; }
        public int AliveCells { get; set; }
        public int Generation { get; private set; }
        public bool[,] NowGeneration;
        public bool[,] NextGeneration;
        public List<int> AliveCellsStats = new List<int>();



        public GameLogic (int Heigth, int Width)
        {
            this.heigth = Heigth;
            this.width = Width;
            NowGeneration = new bool[Width, Heigth];            //current generation wich we output
            NextGeneration = new bool[Width, Heigth];           //new generation which is used for current generation creation
            GenerateBoard();
        }

 
        /// <summary>
        /// Generates new random board
        /// </summary>
        public void GenerateBoard()
        {
            Random randomBool = new Random();
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < heigth; y++)
                {
                    NowGeneration[x, y] = randomBool.Next(0, 2) == 1;
                }
            }
        }

        /// <summary>
        /// Creates a new generation based on CountNeigbors
        /// </summary>
        public void CreateNextGeneration()
        {
            Generation++;
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < heigth; y++)
                {
                    NextGeneration[x, y] = NowGeneration[x, y];
                    int neighbor = CountNeighbors(x, y);
                    if (neighbor < 2 || neighbor > 3)
                    {
                        NextGeneration[x, y] = false;
                    }
                    else if (neighbor == 3)
                    {
                        NextGeneration[x, y] = true;
                    }
                }
            }
            
        }

        /// <summary>
        /// Switchs NowGeneration and NextGeneration arrays so "main" array is reusable
        /// </summary>
        public void SwitchArrays()
        {
            bool[,] Switched = NowGeneration;
            NowGeneration = NextGeneration;
            NextGeneration = Switched;
        }

        /// <summary>
        /// Counts neighbors
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        private int CountNeighbors(int col, int row)        //coordinates
        {
            int count = 0;
            for (int x = col - 1; x <= col + 1; x++)
            {
                for (int y = row - 1; y <= row + 1; y++)
                {
                    if (x == col && y == row)
                    {
                        continue;
                    }
                    if (IdentifyAliveNeighbor(x, y))
                    {
                        count++;
                    }
                }
            }

            return count;
        }

        /// <summary>
        /// Identifies if neighbqour is alive
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        private bool IdentifyAliveNeighbor (int x, int y)
        {
            if (x < 0 || y < 0) return false;
            {
                if (x >= width || y >= heigth)
                {
                    return false;
                }
            }

            return NowGeneration[x, y];
        }

        /// <summary>
        /// counts total number af alive cells on the board
        /// </summary>
        public void CountNumberOfAliveCells()
        {
            AliveCells = 0;
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < heigth; y++)
                if (NowGeneration[x,y] == true)
                {
                    AliveCells++;
                }
            }
        }

        /// <summary>
        /// Prints number of alive cells on the board
        /// </summary>
        public void PrintNumberOfAliveCells()
        {
            Console.WriteLine("Alive cells: " + AliveCells);
        }

        /// <summary>
        /// Prints number of current generation
        /// </summary>
        public void PrintNumberOfGeneration()
        {
            Console.WriteLine();
            Console.WriteLine("Generation: " + Generation);
        }

        /// <summary>
        /// Saves application into text file using StreamWriter
        /// </summary>
        public void SaveGameToFile()
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(@"C:\Users\renate.tomilova\Desktop\Sample.txt"))
                {
                    for (int x = 0; x < width; x++)
                    {
                        for (int y = 0; y < heigth; y++)
                        {
                            sw.Write(NowGeneration[x, y] ? "O" : " ");
                        }
                        sw.WriteLine();
                    }
                }

            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
            
        }

        /// <summary>
        /// Loads game from the file using StreamReader
        /// </summary>
        public void LoadGame()
        {
            using (StreamReader reader = new StreamReader(@"C:\Users\renate.tomilova\Desktop\Sample.txt"))
            {
                string[] board = reader.ReadLine().Split(" ");
                int width = int.Parse(board[0]);
                int heigth = int.Parse(board[1]);
                NowGeneration = new bool[width, heigth];

                for (int x = 0; x < width; x++)
                {
                    string line = reader.ReadLine();
                    for (int y = 0; y < line.Length; y++)
                    {
                        bool cell = line[y] == '0';
                        NowGeneration[x, y] = cell;
                    }
                }
            }

        }

        /// <summary>
        /// Executes 1 full cycle. Prints board -> create new generation -> switch arrays
        /// </summary>
        public void ExecuteOneFullCycle()
        {
            ConsoleManager console = new ConsoleManager();
            console.PrintBoard(this);
            CreateNextGeneration();
            SwitchArrays();
        }

   }
}



