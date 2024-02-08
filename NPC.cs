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

        private List<List<string>> dialogueSets;
        private int currentDialogueIndex;
        private bool inDialogue;

        public NPC(string name)
        {
            Name = name;
            dialogueSets = new List<List<string>>();
            currentDialogueIndex = 0;
            inDialogue = false;
        }

        public void DrawNPC(Map map, int x, int y)
        {
            map.mapTile[x, y] = '8';
        }

        public void DisplayDialog()
        {
            while (inDialogue && HasMoreDialogues())
            {
                string currentDialogue = GetRandomDialogue();
                Console.WriteLine(currentDialogue);
                Console.WriteLine("\n");
                Console.WriteLine("Press Enter to continue...");

                while (Console.ReadKey(true).Key != ConsoleKey.Enter) ;

                NextDialogue();
            }

            inDialogue = false;
            Console.Clear();
        }

        public void AddDialogueSet(List<string> dialogueSet)
        {
            dialogueSets.Add(dialogueSet);
        }

        public string GetRandomDialogue()
        {
            if (dialogueSets.Count == 0)
            {
                return "No dialogue available.";
            }

            Random random = new Random();
            int setIndex = random.Next(dialogueSets.Count);
            List<string> selectedSet = dialogueSets[setIndex];

            int dialogueIndex = random.Next(selectedSet.Count);
            return selectedSet[dialogueIndex];
        }

        public bool InDialogue
        {
            get { return inDialogue; }
            set { inDialogue = value; }
        }

        public void NextDialogue()
        {
            Console.Clear();
            currentDialogueIndex++;

            if (currentDialogueIndex >= dialogueSets.Count)
            {
                inDialogue = false;
                currentDialogueIndex = 0;
            }
        }

        public bool HasMoreDialogues()
        {
            return currentDialogueIndex < dialogueSets.Count;
        }

        public bool Interact(Player player)
        {
            if (IsPlayerNearby(player) && !InDialogue)
            {
                InDialogue = true; // Démarre le dialogue
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
