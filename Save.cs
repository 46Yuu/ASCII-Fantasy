using System;
using ASCIIFantasy;
using System.Text.Json;
using System.Diagnostics;

namespace ASCIIFantasy
{
    public class Save
    {
        //static Save instance;
        Player player;
        MapArray map;
        public static Save Data() 
        { 
            Save data = new Save();
            data.player = Player.instance;
            data.map = MapArray.instance;
            return data;
        }

/*        public static Save CreateInstance()
        {
            if(Save.instance == null)
            {
                instance = Save.Data();
            }
            return instance;
        }*/
        public static void LoadData(string file)
        {
            string fileName = file + ".json";
            string jsonFile = System.IO.File.ReadAllText(fileName);
            if(jsonFile == null)
            {
                throw new Exception("File not found");
            }
            Save data = JsonSerializer.Deserialize<Save>(jsonFile);
            Player.instance = data.player;
            MapArray.instance = data.map;
        }

        public static void SaveData(Save data, string file)
        {
            string jsonFile = JsonSerializer.Serialize(data.player)+ "\n" + JsonSerializer.Serialize(data.map);
            string fileName = file + ".json";
            System.IO.File.WriteAllText(fileName, jsonFile);
        }

/*        public static Save GetData()
        {
            return instance;
        }*/


        public static void SaveGame(int slot)
        {
            SaveList.saveList[slot] = Data();
            SaveData(SaveList.saveList[slot], "Save" + (slot +1).ToString());
        }
    }
}
