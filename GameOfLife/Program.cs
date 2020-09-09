using System;

namespace GameOfLife
{
    internal class Program
    {

        private static void Main(string[] args)
        {

            Console.Write("Enter board width: ");
            int width = int.Parse(Console.ReadLine());
            if (width <= 0 || width > 50)
            {
                Console.WriteLine("Entered number is out of range. Please enter a number from 1 to 50.");
            }

            Console.Write("Enter board heigth: ");
            int heigth = int.Parse(Console.ReadLine());
            if (heigth <= 0 || width > 50)
            {
                Console.WriteLine("Entered number is out of range. Please enter a number from 1 to 50.");
            }
            //check entered value
            //check entered number

            Game session = new Game(heigth, width);

            session.StartGame();

            int gen = 0;        // will be used for generation counting

            while (gen++ < 100)
            {
                session.FullCycle();
                Console.WriteLine();
                Console.WriteLine("Generation: " + gen);
                Console.Write("Alive cells: " );
                System.Threading.Thread.Sleep(1000);
            }
        }
    }
}

