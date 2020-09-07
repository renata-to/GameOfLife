using System;

namespace GameOfLife
{
    internal class Program
    {

        private static void Main(string[] args)
        {
            Game session = new Game();                  // create a new session

            session.StartGame();                        // 1. start a new game
            session.GenerateBoard();                    // 2. generate field

            int gen = 0;        // will be used for generation counting

            while (gen++ < 100)                         // 3. grow the generation
            {
                session.Generation();
                System.Threading.Thread.Sleep(1000);     // 4. repeat
            }
        }
    }
}

