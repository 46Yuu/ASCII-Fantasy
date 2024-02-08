using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ASCIIFantasy
{
    public class NPC
    {
        public string Name { get; private set; }
        public int PositionX { get; private set; }
        public int PositionY { get; private set; }

        private Dialogue dialogue;
        private bool inDialogue;

        public NPC(string name, List<List<string>> dialogues)
        {
            Name = name;
            dialogue = new Dialogue(dialogues);
            inDialogue = false;
        }

        public void DrawNPC(Map map, int x, int y)
        {
            map.mapTile[x, y] = '8';
        }

        public void DisplayDialog()
        {
            while (inDialogue && dialogue.HasMoreDialogues())
            {
                string currentDialogue = dialogue.GetRandomDialogue();
                Console.WriteLine(currentDialogue);
                Console.WriteLine("\n");
                Console.WriteLine("Press Enter to continue...");

                while (Console.ReadKey(true).Key != ConsoleKey.Enter) ;

                dialogue.NextDialogue();
            }

            inDialogue = false;
            Console.Clear();
        }

        public bool Interact(Player player)
        {
            if (IsPlayerNearby(player) && !inDialogue)
            {
                inDialogue = true;
                return true;
            }

            return false;
        }

        private bool IsPlayerNearby(Player player)
        {
            return (Math.Abs(player.positionX - PositionX) <= 1 && player.positionY == PositionY) ||
                   (Math.Abs(player.positionY - PositionY) <= 1 && player.positionX == PositionX);
        }
    }
}
