using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASCIIFantasy
{
    class NPCList
    {
        public List<NPC> listNPCs = new List<NPC>();
        public static NPCList instance;

        NPC npc1 = new NPC("NPC1", new List<List<string>> {
        new List<string> { "Dialogue 1", "Dialogue 2", "Dialogue 3" }
    });
        NPC npc2 = new NPC("NPC2", new List<List<string>> {
        new List<string> { "Dialogue A", "Dialogue B", "Dialogue C" }
    });
        NPC npc3 = new NPC("NPC3", new List<List<string>> {
        new List<string> { "Dialogue X", "Dialogue Y", "Dialogue Z" }
    });

        public NPCList()
        {
            listNPCs.Add(npc1);
            listNPCs.Add(npc2);
            listNPCs.Add(npc3);
        }

        public static NPCList CreateInstance()
        {
            if (instance == null)
            {
                instance = new NPCList();
            }
            return instance;
        }
    }
}
