using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using GameOfLife;
using Newtonsoft.Json;

namespace GameOfLife
{
    public class FileManager
    {
        private string fileName;

        public FileManager(string fileName)
        {
            this.fileName = fileName;
        }


        /// <summary>
        /// Saves the game
        /// </summary>
        public void SaveGame(List<GameLogic> games)
        {
            try
            {
                //string jsonString;
                //File.WriteAllText(@"C:\Users\renate.tomilova\Desktop\Sample.txt", jsonString);

                var game = new JsonSerializerSettings { Formatting = Formatting.Indented };
                var session = new GameManager
                {
                    Games = new List<GameLogic>
                    {

                    }
                };

                var file = JsonConvert.SerializeObject(session);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public GameManager LoadGame()
        {
            try
            {
                string jsonString = File.ReadAllText(@"C:\Users\renate.tomilova\Desktop\Sample.txt");
                var gameLogic = JsonConvert.DeserializeObject<GameManager>(jsonString);
                return null;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

    }
}
