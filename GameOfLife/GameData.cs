using System;
using System.Collections.Generic;
using System.Text;

namespace GameOfLife
{
    /// <summary>
    /// holds data that is saved to the file
    /// </summary>
    public class GameData
    {
        public bool[,] NowGeneration { get; set;  }
        public int Generation { get; set; }
    }
}
