using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASCIIFantasy
{
    public class DialogueList
    {
        public List<Dialogue> listDialogues = new List<Dialogue>();
        public static DialogueList instance;

        public DialogueList()
        {
            listDialogues.Add(new Dialogue(new List<string> { "Dialogue 1", "Dialogue 2", "Dialogue 3" }));
            listDialogues.Add(new Dialogue(new List<string> { "Dialogue A", "Dialogue B", "Dialogue C" }));
            listDialogues.Add(new Dialogue(new List<string> { "Dialogue X", "Dialogue Y", "Dialogue Z" }));
            // Ajoutez d'autres dialogues selon vos besoins
        }

        public static DialogueList CreateInstance()
        {
            if (instance == null)
            {
                instance = new DialogueList();
            }
            return instance;
        }
    }
}
