﻿using System;
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

                var data = games.Select(game => game.AsGameData()).ToList();
                var json = JsonConvert.SerializeObject(data, Formatting.Indented);
                File.WriteAllText(fileName, json);

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public List<GameLogic> LoadGame()
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
