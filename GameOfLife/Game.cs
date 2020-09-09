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

        public Game (int heigth, int width)             //1.
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

        public void CheckTheEnteredValue()      //checks if entered value is numeric
        {
            int value;
            while (!int.TryParse(Console.ReadLine(), out value))
            {
                Console.WriteLine("Entered value is not numeric.");
            }
        }
        private void GenerateBoard()                     //generates new board with random chars and prints it out       2.
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

        public void OutputBoard()                               // 3.
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

        /*private int NumOfNeighbours(int col, int row)       //counts the number of neighbours           4.
        {
            int Neighbours = 0;

            for (int x = col - 1; x < col + 2; x++){
                for (int y = row - 1; y < row + 2; y++){
                    if (!((x < 0 || y < 0) || (x >= heigth || y >= width))){
                        if (Table[x, y] == true) Neighbours++;
                    }
                }
            }
            return Neighbours;
        }*/

        private int GetNeighbors(int x, int y)
        {
            int NumOfAliveNeighbors = 0;

            for (int i = x - 1; i < x + 2; i++)
            {
                for (int j = y - 1; j < y + 2; j++)
                {
                    if (!((i < 0 || j < 0) || (i >= Table.GetLength(1) || j >= Table.GetLength(1))))
                    {
                        if (Table[i, j] == true) { NumOfAliveNeighbors++; }
                    }
                }
            }
            return NumOfAliveNeighbors;

        }
            public void Generation()                        //grows the field based on NumOfNeighbours          5.
        {
            // if <2 cell dies
            // if 2 or 3 cell lives
            // if >3 cell dies
            // if =3 cell becomes alive

            for (int x = 0; x < Table.GetLength(1); x++)
            {
                for (int y = 0; y < Table.GetLength(1); y++)
                {
                    int numOfAliveNeighbours = GetNeighbors(x, y);

                    if (Table[x, y])
                    {
                        if (numOfAliveNeighbours < 2)
                        {
                            Table[x, y] = false;      //cell dies
                        }

                        if (numOfAliveNeighbours > 3)
                        {
                            Table[x, y] = false;      //cell dies
                        }

                        else
                        {
                            if (numOfAliveNeighbours == 3)
                            {
                                Table[x, y] = true;    //cell becomes alive
                            }
                        }
                    }
                }
            }
        }

        public void FullCycle()
        {
            OutputBoard();
            Generation();
        }

   }
}



