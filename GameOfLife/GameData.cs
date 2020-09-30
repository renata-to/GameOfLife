using System;
using System.Collections.Generic;
using System.Text;

namespace GameOfLife
{
    public class GameData
    {
        public bool[,] NowGeneration { get; set;  }
        public int Generation { get; set; }
    }
}
