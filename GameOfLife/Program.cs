using System;

namespace GameOfLife
{
    internal class Program
    {

        private static void Main(string[] args)
        {
            Console.Write("Enter board width: ");
            int width = int.Parse(Console.ReadLine());
            Console.Write("Enter board heigth: ");
            int heigth = int.Parse(Console.ReadLine());

            Game session = new Game(heigth, width);                  // create a new session

            session.StartGame();                        // 1. start a new game                // 2. generate field

            int gen = 0;        // will be used for generation counting

            while (gen++ < 100)                         // 3. grow the generation
            {
                session.FullCycle();
                System.Threading.Thread.Sleep(1000);     // 4. repeat
            }
        }
    }
}

