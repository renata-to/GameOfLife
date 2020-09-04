using System;

namespace GameOfLife
{
    class Program
    {
        static void Main(string[] args)
        {
            //define board size
            Console.Write("Enter board widht: ");
            int widht = int.Parse(Console.ReadLine());

            Console.Write("Enter board hight: ");
            int hight = int.Parse(Console.ReadLine());
/*
            //create an array which will be used as a board
            int[,] Board = new int[widht, hight];
            Random random = new Random();


            //generate random numbers for array
            for (int i = 0; i < Board.GetLength(0); i++)        //columns
            {
                for (int j = 0; j < Board.GetLength(1); j++)    //rows
                {
                    Board[i, j] = random.Next(1);
                }

            }

            //fill array with random numbers
            for (int y = 0; y < Board.GetLength(0); y++)
            {
                for (int x = 0; x < Board.GetLength(1); x++)
                {
                    Console.Write(Board[y, x]);
                }
                Console.WriteLine();
            }
 */

            //HOW TO GET AN ARRAY WITH CHARACTERS?!

            bool[,] Table = new bool[widht, hight];

            //generate random numbers for bool array
            Random randomBool = new Random();

            for (int c = 0; c < Table.GetLength(0); c++)
            {
                for (int h = 0; h < Table.GetLength(1); h++)
                {
                    int character = randomBool.Next(2);
                    Table[c, h] = ((character == 0) ? false : true);
                    
                }
            }

 /*           for (int y = 0; y < Table.GetLength(0); y++)
            {
                for (int x = 0; x < Table.GetLength(1); x++)
                {
                    Console.Write(Table[y, x]);
                }
                Console.WriteLine();
            }
 */
            //replace TRUEs and FALSEs
            for (int i = 0; i < Table.GetLength(1); i++ )
            {
                for (int j = 0; j < Table.GetLength(1); j++)
                {
                    Console.Write(Table[i, j] ? "O" : " ");
                    if (j == widht - 1) Console.WriteLine();
                }
            }

            //Count neighbours

            int z;
            int q;
            int Neighbours = 0;

            for (int i = z - 1; i < z + 2; i++)
            {
               for (int j = q - 1; j < q + 2; j++)
                {
                    if (!((i < 0 || (i >= Table.GetLength(1) || j >= Table.GetLength(1)))))
                    {
                        if (Table[i, i] == true) Neighbours++;
                    }
                }
            }


            Console.ReadLine();
        }
    }
}
