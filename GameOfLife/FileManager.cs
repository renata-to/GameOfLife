using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using GameOfLife;
using Newtonsoft.Json;

namespace GameOfLife
{
    /// <summary>
    /// Manages game saving to the file / opening from the file
    /// </summary>
    public class FileManager
    {
        private string fileName;

        public FileManager(string fileName)
        {
            this.fileName = fileName;
        }

        /// <summary>
        /// Saves game to the file
        /// </summary>
        public void SaveGames(List<GameLogic> games)
        {
            try
            {
                var data = games.Select(game => game.AsGameData()).ToList();
                var json = JsonConvert.SerializeObject(data, Formatting.Indented);
                File.WriteAllText(fileName, json);

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        /// <summary>
        /// Loads game from the file
        /// </summary>
        /// <returns></returns>
        public List<GameLogic> LoadGames()
        {
            try
            {
                string json = File.ReadAllText(fileName);
                var data = JsonConvert.DeserializeObject<List<GameData>>(json);
                return data.Select(info => new GameLogic(info.NowGeneration, info.Generation)).ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

    }
}
