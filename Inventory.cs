/*using ASCIIFantasy;
using System;

class Inventory
{
    List<GearPiece> listGearInventory;
    //List<Item> listItemInventory;

    public Inventory()
    {
        listGearInventory = new List<GearPiece>();
    }

    public void AddGear(GearPiece c)
    {
        listGearInventory.Add(c);
    }

    public void RemoveGear(GearPiece c)
    {
        listGearInventory.Remove(c);
    }


    public void SelectCharacter()
    {
        string[] options = new string[this.listGearInventory.Count + 1];
        options[0] = "Return";
        int selectedIndex = 0;
        bool isChoiceDone = false;
        for (int i = 0; i < listCharacters.Count; i++)
        {
            options[i + 1] = listCharacters[i].GetName();
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
        for (int i = 0; i < optionLength; i++)
        {
            if (i < _selected.GetGear().pieces.Count)
            {
                if (_selected.GetGear().pieces[i] != null)
                {
                    options[i + 1] = $"{_selected.GetGear().pieces[i].type.ToString()} : {_selected.GetGear().pieces[i].gearName}";
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
                        options[i + 1] = $"Health : {_selected.GetStats().statsList[i - 5]} (+ {_selected.GetStats().GetBonusHealth()}) : {_selected.GetStats().statsList[i - 5] + _selected.GetStats().GetBonusHealth()}";
                        break;
                    case 6:
                        options[i + 1] = $"Mana : {_selected.GetStats().statsList[i - 5]} (+{_selected.GetStats().GetBonusMana()}) : {_selected.GetStats().statsList[i - 5] + _selected.GetStats().GetBonusMana()}";
                        break;
                    case 7:
                        options[i + 1] = $"Attack : {_selected.GetStats().statsList[i - 5]} (+{_selected.GetStats().GetBonusAttack()}) : {_selected.GetStats().statsList[i - 5] + _selected.GetStats().GetBonusAttack()}";
                        break;
                    case 8:
                        options[i + 1] = $"Defense : {_selected.GetStats().statsList[i - 5]} (+{_selected.GetStats().GetBonusDefense()}) : {_selected.GetStats().statsList[i - 5] + _selected.GetStats().GetBonusDefense()}";
                        break;
                    case 9:
                        options[i + 1] = $"Intelligence : {_selected.GetStats().statsList[i - 5]} (+{_selected.GetStats().GetBonusIntelligence()}) : {_selected.GetStats().statsList[i - 5] + _selected.GetStats().GetBonusIntelligence()}";
                        break;
                    case 10:
                        options[i + 1] = $"Agility : {_selected.GetStats().statsList[i - 5]} (+{_selected.GetStats().GetBonusAgility()}) : {_selected.GetStats().statsList[i - 5] + _selected.GetStats().GetBonusAgility()}";
                        break;
                    case 11:
                        options[i + 1] = $"Luck : {_selected.GetStats().statsList[i - 5]} (+{_selected.GetStats().GetBonusLuck()}) : {_selected.GetStats().statsList[i - 5] + _selected.GetStats().GetBonusLuck()}";
                        break;
                }
            }
        }

        while (!isChoiceDone)
        {
            DisplayCharacterStats(_selected, options, selectedIndex);

            ConsoleKeyInfo keyInfo = Console.ReadKey();
            Console.Clear();

            if (keyInfo.Key == ConsoleKey.Enter)
            {
                switch (selectedIndex)
                {
                    case 0:
                        SelectCharacter();
                        break;
                    case 1:
                        SelectGearToEquip(GearPiece.GearType.Head);
                        break;
                    case 2:
                        SelectGearToEquip(GearPiece.GearType.Chest);
                        break;
                    case 3:
                        SelectGearToEquip(GearPiece.GearType.Legs);
                        break;
                    case 4:
                        SelectGearToEquip(GearPiece.GearType.Feet);
                        break;
                    case 5:
                        SelectGearToEquip(GearPiece.GearType.Weapon);
                        break;
                    case 6:
                        break;
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

    private void SelectGearToEquip(GearPiece.GearType _selectedGear)
    {
        GearList list = new GearList();
        string[] options = new string[list.listGear.Count + 1];
        options[0] = "Return";
        int selectedIndex = 0;
        bool isChoiceDone = false;
        for (int i = 0; i < list.listGear.Count; i++)
        {
            options[i + 1] = list.listGear[i].gearName;
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

    public void DisplayCharacterStats(Character _selected, string[] _options, int _selectedIndex)
    {
        for (int i = 0; i < _options.Length; i++)
        {
            if (i == 1)
            {
                Console.Write("\t++ GEAR ++\n\n");
            }
            else if (i == 6)
            {
                Console.WriteLine("\n\n\t++ STATS ++\n");
            }
            if (i == _selectedIndex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(" > ");
                Console.WriteLine(_options[i] + "\n");
                Console.ResetColor();
            }
            else
            {
                Console.Write("   ");
                Console.WriteLine(_options[i] + "\n");
            }
        }
    }


    public void DisplayPlayerChoice(List<Character> listCharacters, string[] options, int selectedIndex)
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
*/