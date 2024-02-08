using System;
using ASCIIFantasy;
using System.Text.Json;

namespace ASCIIFantasy
{
    public class Save
    {
        static Save instance;
        Player player;
        MapArray map;
        public static Save Data() 
        { 
            Save data = new Save();
            data.player = Player.instance;
            data.map = MapArray.instance;
            return data;
        }

        public static Save CreateInstance()
        {
            if(Save.instance == null)
            {
                instance = Save.Data();
            }
            return instance;
        }

        public static void SaveData(Save data)
        {
            string jsonFile = JsonSerializer.Serialize(data);
        }
        static void SetInstance(Save instance)
        {
            Save.instance = instance;
        }
    }
}
