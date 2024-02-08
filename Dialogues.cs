using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASCIIFantasy
{
    public class Dialogue
    {
        private List<List<string>> dialogueSets;
        private int currentSetIndex;
        private int currentDialogueIndex;

        public Dialogue(List<List<string>> dialogues)
        {
            dialogueSets = dialogues;
            currentSetIndex = 0;
            currentDialogueIndex = 0;
        }

        public string GetRandomDialogue()
        {
            if (dialogueSets.Count == 0)
            {
                return "No dialogue available.";
            }

            Random random = new Random();
            List<string> selectedSet = dialogueSets[currentSetIndex];

            int dialogueIndex = random.Next(selectedSet.Count);
            return selectedSet[dialogueIndex];
        }

        public void NextDialogue()
        {
            currentDialogueIndex++;

            if (currentDialogueIndex >= dialogueSets[currentSetIndex].Count)
            {
                currentDialogueIndex = 0;
                currentSetIndex++;
                if (currentSetIndex >= dialogueSets.Count)
                {
                    currentSetIndex = 0;
                }
            }
        }

        public bool HasMoreDialogues()
        {
            return currentSetIndex < dialogueSets.Count && currentDialogueIndex < dialogueSets[currentSetIndex].Count;
        }
    }
}
