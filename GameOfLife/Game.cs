using System;
using System.Collections.Generic;
using System.Text;

namespace GameOfLife
{
    public class Game
    {
        public int heigth;
        public int width;
        public bool[,] Table;

        public Game (int heigth, int width)
        {
            this.heigth = heigth;
            this.width = width;
            Table = new bool[width, heigth];
            GenerateBoard();
        }
        public void StartGame()                         //starts the game by proposing select field's size
        {
            //define board size
           // Console.Write("Enter board width: ");
            //width = int.Parse(Console.ReadLine());      // TO DO: check if user entered number

            /* CheckTheEnteredValue();

            if (width <= 0)
            {
                Console.WriteLine("Entered number is negative. Please enter a positive number.");
            }
            */
            // Console.Write("Enter board heigth: ");
            // heigth = int.Parse(Console.ReadLine());
            /*
            CheckTheEnteredValue();
            if (heigth <= 0)
            {
                Console.WriteLine("Entered number is negative. Please enter a positive number.");
            }*/

        }

        public void CheckTheEnteredValue()      //checks if entered value is numeric        can be moved to program
        {
            int value;
            while (!int.TryParse(Console.ReadLine(), out value))
            {
                Console.WriteLine("Entered value is not numeric.");
            }
        }
        private void GenerateBoard()                     //generates new board with random chars and prints it out
        {
            //generate random numbers for bool array
            Random randomBool = new Random();

            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < heigth; y++)
                {
                    Table[x, y] = randomBool.Next(0, 2) == 1;

                }
            }
        }

        public void OutputBoard()
        {
            Console.Clear();
            Console.WriteLine();
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < heigth; y++)
                {
                    Console.Write(Table[x, y] ? "O" : " ");
                }
                Console.WriteLine();
            }
            //Console.SetCursorPosition(0, Console.WindowTop);
        }

        private void Generation()
        {
            for (int x = 0; x < heigth; x++)
            {
                for (int y = 0; y < width; y++)
                {
                    int numOfAliveNeighbors = NumOfNeighbors(x, y);

                    if (Table[x, y])
                    {
                        if (numOfAliveNeighbors < 2)
                        {
                            Table[x, y] = false;
                        }

                        if (numOfAliveNeighbors > 3)
                        {
                            Table[x, y] = false;
                        }
                    }
                    else
                    {
                        if (numOfAliveNeighbors == 3)
                        {
                            Table[x, y] = true;
                        }
                    }
                }
            }
        }

        private int NumOfNeighbors(int row, int col)
        {
            int NumOfAliveNeighbors = 0;
            for (int x = row - 1; x < row + 2; x++)
            {
                for (int y = col - 1; y < col + 2; y++)
                {
                    if (!((x < 0 || y < 0) || (x >= heigth || y >= width)))
                    {
                        if (Table[x, y] == true) NumOfAliveNeighbors++;
                    }
                }
            }
            return NumOfAliveNeighbors;
        }

        public void FullCycle()
        {
            OutputBoard();
            Generation();
        }

   }
}



