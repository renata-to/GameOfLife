using System;
using System.IO;
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
        public void SaveGame(GameLogic gamelogic)
        {
            string jsonString;
            jsonString = JsonConvert.SerializeObject(gamelogic);
            File.WriteAllText(@"C: \Users\renate.tomilova\Desktop\Sample.txt", jsonString);
        }

        public GameManager LoadGame()
        {
            try
            {
                string jsonString = File.ReadAllText(@"C: \Users\renate.tomilova\Desktop\Sample.txt");
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
