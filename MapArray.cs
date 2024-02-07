using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASCIIFantasy
{
    public class MapArray
    {
        public Map activeMap { get; set; }
        public Map[,] maps = new Map[198,198];

        public static MapArray instance;

        public static MapArray CreateInstance()
        {
            if (instance == null)
            {
                instance = new MapArray();
            }
            return instance;
        }
    }
}
