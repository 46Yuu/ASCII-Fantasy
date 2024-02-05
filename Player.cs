using ASCIIFantasy;
using System;

class Player : Character
{
   List<Character> listCharacters;


    public Player()
    {
        listCharacters = new List<Character>();
    }

    public void AddCharacter(Character c)
    {
        listCharacters.Add(c);
    }

    public void RemoveCharacter(Character c)
    {
        listCharacters.Remove(c);
    }


    public void SelectCharacter()
    {
        string[] options = new string[this.listCharacters.Count+1];
        options[0] = "Return";
        int selectedIndex = 0;
        bool isChoiceDone = false;
        for (int i = 0; i < listCharacters.Count; i++)
        {
            options[i+1] = listCharacters[i].GetName();
        }
        while (!isChoiceDone)
        {
            DisplayPlayerChoice(this.listCharacters, options, selectedIndex);

            ConsoleKeyInfo keyInfo = Console.ReadKey();
            Console.Clear();

            if (keyInfo.Key == ConsoleKey.Enter)
            {
                if (selectedIndex == 0)
                {
                    isChoiceDone = true;
                }
                else
                {
                    SelectCharacterMenu(listCharacters[selectedIndex]);
                }
            }
            else
            {
                switch (keyInfo.Key)
                {
                    case ConsoleKey.UpArrow:
                        selectedIndex = (selectedIndex - 1 + options.Length) % options.Length;
                        break;
                    case ConsoleKey.DownArrow:
                        selectedIndex = (selectedIndex + 1) % options.Length;
                        break;
                }
            }
        }
        //renvoie au menu précédent
    }

    public void SelectCharacterMenu(Character _selected)
    {
        int optionLength = _selected.GetGear().pieces.Count + _selected.GetStats().statsList.Count;
        string[] options = new string[optionLength + 1];
        int selectedIndex = 0;
        options[0] = "Return";
        bool isChoiceDone = false;
        for (int i = 0; i <optionLength; i++)
        {
            if(i < _selected.GetGear().pieces.Count)
            {
                if (_selected.GetGear().pieces[i] != null)
                {
                    options[i +1] =_selected.GetGear().pieces[i].type.ToString();
                }
                else
                {
                    options[i + 1] = "No Gear Equiped";
                }
            }
            else
            {
                switch (i)
                {
                    case 5:
                        options[i + 1] = "Health";
                        break;
                    case 6:
                        options[i + 1] = "Mana";
                        break;
                    case 7:
                        options[i + 1] = "Attack";
                        break;
                    case 8:
                        options[i + 1] = "Defense";
                        break;
                    case 9:
                        options[i + 1] = "Intelligence";
                        break;
                    case 10:
                        options[i + 1] = "Agility";
                        break;
                    case 11:
                        options[i + 1] = "Luck";
                        break;
                }
            }
        }

        while (!isChoiceDone)
        {
            DisplayCharacterStats(_selected,options,  selectedIndex);

            ConsoleKeyInfo keyInfo = Console.ReadKey();
            Console.Clear();

            if (keyInfo.Key == ConsoleKey.Enter)
            {
                if(selectedIndex == 0)
                {
                    SelectCharacter();
                }
                else
                {
                    /*Si c'est un gear
                            Ouvre Bag et select le gear
                    Sinon
                           +1 a la stat
                     */
                }
            }
            else
            {
                switch (keyInfo.Key)
                {
                    case ConsoleKey.UpArrow:
                        selectedIndex = (selectedIndex - 1 + options.Length) % options.Length;
                        break;
                    case ConsoleKey.DownArrow:
                        selectedIndex = (selectedIndex + 1) % options.Length;
                        break;
                }
            }
        }
    }

    public void DisplayCharacterStats(Character _selected, string[] _options, int _selectedIndex)
    {
        for (int i = 0; i < _options.Length; i++)
        {
            if (i == _selectedIndex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(" > ");
                Console.WriteLine(_options[i]);
                Console.ResetColor();
            }
            else
            {
                Console.Write("   ");
                Console.WriteLine(_options[i]);
            }
        }
    }


    public void DisplayPlayerChoice( List<Character> listCharacters,string[] options, int selectedIndex)
    {
        for (int i = 0; i < options.Length; i++)
        {
            if (i == selectedIndex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(" > ");
                Console.WriteLine(options[i]);
                Console.ResetColor();
            }
            else
            {
                Console.Write("   ");
                Console.WriteLine(options[i]);
            }
        }
    }

    static void Main(string[] args)
    {
        Character player1 = new Character("Player1", 100, 100, 10, 10, 10, 10, 10);
        Character player2 = new Character("Player2", 100, 100, 10, 10, 10, 10, 10);
        Player player = new Player();
        player.listCharacters.Add(player1);
        player.listCharacters.Add(player2);
        player1.AddAttack("Fireball");
        player1.AddAttack("Bulk_up");
        player2.AddAttack("Fireball");
        player.SelectCharacter();
    }

}
