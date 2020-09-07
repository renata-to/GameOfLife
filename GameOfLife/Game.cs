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
        public void StartGame()                         //starts the game by proposing select field's size
        {
            //define board size
            Console.Write("Enter board width: ");
            width = int.Parse(Console.ReadLine());      // TO DO: check if user entered number


            Console.Write("Enter board heigth: ");
            heigth = int.Parse(Console.ReadLine());

        }
        public void GenerateBoard(int width, int heigth)                     //generates new board with random chars and prints it out
        {

            bool[,] Table = new bool[width, heigth];

            //generate random numbers for bool array
            Random randomBool = new Random();

            for (int i = 0; i < Table.GetLength(1); i++)
            {
                for (int j = 0; j < Table.GetLength(1); j++)
                {
                    int character = randomBool.Next(2);
                    Table[i, j] = ((character == 0) ? false : true);

                }
            }
        }

        public void OutputBoard()
        {
            for (int i = 0; i < Table.GetLength(1); i++)
            {
                for (int j = 0; j < Table.GetLength(1); j++)
                {
                    Console.Write(Table[i, j] ? "O" : " ");
                    if (j == Table.GetLength(1) - 1) Console.WriteLine();
                }
            }
        }
        private int NumOfNeighbours(int z, int q)       //counts the number of neighbours
        {
            int Neighbours = 0;

            for (int i = z - 1; i < z + 2; i++)
            {
                for (int j = q - 1; j < q + 2; j++)
                {
                    if (!((i < 0 || (i >= Table.GetLength(1) || j >= Table.GetLength(1)))))
                    {
                        if (Table[i, j] == true) Neighbours++;
                    }
                }
            }

            return Neighbours;
        }
        public void Generation()                        //grows the field based on NumOfNeighbours
        {
            // if <2 cell dies
            // if 2 or 3 cell lives
            // if >3 cell dies
            // if =3 cell becomes alive

            for (int i = 0; i < Table.GetLength(1); i++)
            {
                for (int j = 0; j < Table.GetLength(1); j++)
                {
                    int numOfAliveNeighbours = NumOfNeighbours(i, j);

                    if (Table[i, j])
                    {
                        if (numOfAliveNeighbours < 2)
                        {
                            Table[i, j] = false;      //cell dies
                        }

                        if (numOfAliveNeighbours > 3)
                        {
                            Table[i, j] = false;      //cell dies
                        }

                        else
                        {
                            if (numOfAliveNeighbours == 3)
                            {
                                Table[i, j] = true;    //cell becomes alive
                            }
                        }
                    }
                }
            }
        }

    }
}
