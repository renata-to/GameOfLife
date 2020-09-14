using System;
using System.Collections.Generic;
using System.Text;

namespace GameOfLife
{
    public class Game
    {
        public int Heigth;
        public int Width;
        public int AliveCells;
        public bool[,] NowGeneration;
        public bool[,] NextGeneration;


        public Game (int Heigth, int Width)
        {
            this.Heigth = Heigth;
            this.Width = Width;
            NowGeneration = new bool[Width, Heigth];            //current generation wich we output
            NextGeneration = new bool[Width, Heigth];           //new generation which is used for current generation creation
            GenerateBoard();
        }

        /// <summary>
        /// starts the game by proposing select field's size
        /// currently is in program class
        /// </summary>
        public void StartGame()
        {
            //define board size
           // Console.Write("Enter board Width: ");
            //Width = int.Parse(Console.ReadLine());      // TO DO: check if user entered number

            /* CheckTheEnteredValue();

            if (Width <= 0)
            {
                Console.WriteLine("Entered number is negative. Please enter a positive number.");
            }
            */
            // Console.Write("Enter board Heigth: ");
            // Heigth = int.Parse(Console.ReadLine());
            /*
            CheckTheEnteredValue();
            if (Heigth <= 0)
            {
                Console.WriteLine("Entered number is negative. Please enter a positive number.");
            }*/
        }

        /// <summary>
        /// Checks if entered value is numeric
        /// </summary>
        public void CheckTheEnteredValue()
        {
            int value;
            while (!int.TryParse(Console.ReadLine(), out value))
            {
                Console.WriteLine("Entered value is not numeric.");
            }
        }

        /// <summary>
        /// Generates new random board
        /// </summary>
        private void GenerateBoard()
        {
            Random randomBool = new Random();
            for (int x = 0; x < Width; x++)
            {
                for (int y = 0; y < Heigth; y++)
                {
                    NowGeneration[x, y] = randomBool.Next(0, 2) == 1;
                }
            }
        }

        /// <summary>
        /// Prints out a board
        /// </summary>
        public void PrintBoard()
        {
            Console.Clear();
            Console.WriteLine();
            for (int x = 0; x < Width; x++)
            {
                for (int y = 0; y < Heigth; y++)
                {
                    Console.Write(NowGeneration[x, y] ? "O" : " ");
                }
                Console.WriteLine();
            }
            //Console.SetCursorPosition(0, Console.WindowTop);
        }

        /// <summary>
        /// Creates a new generation based on CountNeigbors
        /// </summary>
        private void CreateNextGeneration()
        {
            for (int i = 0; i < Width; i++)
            {
                for (int j = 0; j < Heigth; j++)
                {
                    NextGeneration[i, j] = NowGeneration[i, j];
                    int neighbor = CountNeighbors(i, j);
                    if (neighbor < 2 || neighbor > 3)
                    {
                        NextGeneration[i, j] = false;
                    }
                    else if (neighbor == 3)
                    {
                        NextGeneration[i, j] = true;
                    }
                }
            }
            bool[,] temp = NowGeneration;               //replacing arrays
            NowGeneration = NextGeneration;
            NextGeneration = temp;
        }

        /// <summary>
        /// Counts neighbors
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        private int CountNeighbors(int x, int y)
        {
            int count = 0;
            for (int i = x - 1; i <= x + 1; i++)
            {
                for (int j = y - 1; j <= y + 1; j++)
                {
                    if (i == x && j == y) continue;
                    if (IdentifyAliveNeighbor(i, j)) count++;
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
                if (x >= Width || y >= Heigth)
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
            for (int x = 0; x < Width; x++ )
            {
                for (int y = 0; y < Heigth; y++)
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

        public void SaveToFile()
        {

        }

        /// <summary>
        /// Executes full cycle = PrintsBoard + CreateNextGeneration
        /// </summary>
        public void ExecuteFullCycle()
        {
            PrintBoard();
            CreateNextGeneration();
        }

   }
}



