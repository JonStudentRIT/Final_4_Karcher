using System;
using System.IO;
using Newtonsoft.Json;

namespace Final_4
{
    //{"player_name":"dschuh","level":4,"hp":99,"inventory":["spear","water bottle","hammer","sonic screwdriver","cannonball","wood","Scooby snack","Hydra","poisonous potato","dead bush","repair powder"],"license_key":"DFGU99-1454"}
    class Program
    {
        static void Main(string[] args)
        {
            // a reference for the file name
            string fileName = "";
            // enter a new path
            Console.WriteLine("Enter a path");
            fileName = Console.ReadLine();
            // or just copy it in as a set path
            //fileName = "C:/SaveFile.json";
            // create a player to save
            PlayerSettings savedPlayer = new PlayerSettings();
            // create a reference to load
            PlayerSettings loadedPlayer;
            // set the saves players data
            savedPlayer.player_name = "dschuh";
            savedPlayer.level = 4;
            savedPlayer.hp = 99;
            savedPlayer.inventory = new string[11];
            savedPlayer.inventory[0] = "spear";
            savedPlayer.inventory[1] = "water bottle";
            savedPlayer.inventory[2] = "hammer";
            savedPlayer.inventory[3] = "sonic screwdriver";
            savedPlayer.inventory[4] = "cannonball";
            savedPlayer.inventory[5] = "wood";
            savedPlayer.inventory[6] = "Scooby snack";
            savedPlayer.inventory[7] = "Hydra";
            savedPlayer.inventory[8] = "poisonous potato";
            savedPlayer.inventory[9] = "dead bush";
            savedPlayer.inventory[10] = "repair powder";
            savedPlayer.license_key = "DFGU99-1454";
            // save the saved player
            SettingsClass.GetInstance().SavePlayerSettings(fileName, savedPlayer);
            // load the lile to the loaded player
            loadedPlayer = SettingsClass.GetInstance().LoadPlayerSettings(fileName);
            // output the data of the loaded player
            Console.WriteLine
                (
                    "Name: " + loadedPlayer.player_name + "\n" +
                    "Level: " + loadedPlayer.level + "\n" +
                    "HP: " + loadedPlayer.hp + "\n" +
                    "Inventory: " + "\n" +
                    "   " + loadedPlayer.inventory[0] + "\n" +
                    "   " + loadedPlayer.inventory[1] + "\n" +
                    "   " + loadedPlayer.inventory[2] + "\n" +
                    "   " + loadedPlayer.inventory[3] + "\n" +
                    "   " + loadedPlayer.inventory[4] + "\n" +
                    "   " + loadedPlayer.inventory[5] + "\n" +
                    "   " + loadedPlayer.inventory[6] + "\n" +
                    "   " + loadedPlayer.inventory[7] + "\n" +
                    "   " + loadedPlayer.inventory[8] + "\n" +
                    "   " + loadedPlayer.inventory[9] + "\n" +
                    "   " + loadedPlayer.inventory[10] + "\n" +
                    "License Key: " + loadedPlayer.license_key
                );
        }
        public class PlayerSettings
        {
            // the player data to be stored
            public string player_name;
            public int level;
            public int hp;
            public string[] inventory;
            public string license_key;
        }
        public interface IPlayerSettings
        {
            // save the player data
            void SavePlayerSettings(string fileName, PlayerSettings settings);
            // load the player data
            PlayerSettings LoadPlayerSettings(string fileName);
        }
        public class SettingsClass : IPlayerSettings
        {
            // singalton instance 
            private static SettingsClass instance = new SettingsClass();
            // constructor
            private SettingsClass()
            { }
            // get the instance
            public static SettingsClass GetInstance()
            {
                return instance;
            }
            public void SavePlayerSettings(string fileName, PlayerSettings settings)
            {
                // a string reference
                string sSettings;
                // wright the string as a json
                sSettings = JsonConvert.SerializeObject(settings);
                // write sSettings to the fileName
                File.WriteAllText(fileName, sSettings);
            }

            public PlayerSettings LoadPlayerSettings(string fileName)
            {
                // a string referece initialized to null
                string sSettings = null;
                // a reference for the player data that is returned
                PlayerSettings settings;
                // read fileName to sSettings
                sSettings = File.ReadAllText(fileName);
                // wright the player data from sSettings
                settings = JsonConvert.DeserializeObject<PlayerSettings>(sSettings);
                return settings;
            }
        }
    }
}
