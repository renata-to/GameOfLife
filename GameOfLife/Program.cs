using System;

namespace GameOfLife
{
    internal class Program
    {

        private static void Main(string[] args)
        {

             Console.Write("Enter board width: ");
             int width;
             while (!int.TryParse(Console.ReadLine(), out width))
             {
                 Console.WriteLine("Entered value is not numeric. Please enter number from 1 to 50: ");
             }
             if (width <= 0 || width > 50)
             {
                 Console.WriteLine("Entered number is out of range. Please enter a number from 1 to 50.");
             }
              
            Console.Write("Enter board heigth: ");
            int heigth;
            while (!int.TryParse(Console.ReadLine(), out heigth))
            {
                Console.WriteLine("Entered value is not numeric.");
            }
            if (heigth <= 0 || heigth > 50)
            {
                Console.WriteLine("Entered number is out of range. Please enter a number from 1 to 50.");
            }
            //check entered value
            //check entered number -> Repeat asking to enter the same parametr till number is in the range

            Game session = new Game(heigth, width);

           // session.StartGame();

            int gen = 0;
            while (gen++ < 100)
            {
                session.ExecuteFullCycle();
                Console.WriteLine();
                Console.WriteLine("Generation: " + gen);
                session.CountNumberOfAliveCells();
                System.Threading.Thread.Sleep(1000);
                //while (Console.ReadKey().Key != ConsoleKey.Enter) { } // added to check if neighbour are counting correctly. will be removed.
                
            }

            Console.ReadLine();
        }
    }
}

