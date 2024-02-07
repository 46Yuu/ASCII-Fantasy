﻿using ASCIIFantasy;
using System;

namespace ASCIIFantasy
{
    public class Inventory
    {
    public List<GearPiece> listGearInventory;
    public List<Item> listItemInventory;

    public Inventory()
    {
        listGearInventory = new();
        listItemInventory = new();

    }

    public void AddGear(GearPiece c)
    {
        listGearInventory.Add(c);
    }

    public void RemoveGear(GearPiece c)
    {
        listGearInventory.Remove(c);
    }

    public void AddItem(Item _item, int _number)
    {
        if (listItemInventory.Contains(_item))
        {
            listItemInventory[listItemInventory.IndexOf(_item)].numberItem += _number;
        }
        else
        {
            _item.numberItem = _number;
            listItemInventory.Add(_item);
        }
    }


    public void SelectGearToDisplay()
    {
        string[] options = new string[this.listGearInventory.Count + 1];
        options[0] = "Return";
        int selectedIndex = 0;
        bool isChoiceDone = false;
        for (int i = 0; i < listGearInventory.Count; i++)
        {
            options[i + 1] = listGearInventory[i].gearName;
        }
        while (!isChoiceDone)
        {
            DisplayGearInventory(options, selectedIndex);

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
                    ShowGearStats(listGearInventory[selectedIndex - 1]);
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

    public void ShowGearStats(GearPiece _gearSelected)
    {
        string[] options = new string[1];
        options[0] = "Return";
        Console.ForegroundColor = ConsoleColor.Red;
        Console.Write(" > ");
        Console.WriteLine(options[0] + "\n");

        while (true)
        {
            DisplayGearStats(_gearSelected);

            ConsoleKeyInfo keyInfo = Console.ReadKey();
            Console.Clear();

            if (keyInfo.Key == ConsoleKey.Enter)
            {
                SelectGearToDisplay();
            }
        }
    }



    public void DisplayGearStats(GearPiece _selectedGear)
    {

        Console.WriteLine(
            $"\t{_selectedGear.gearName.ToUpper()}\n\n" +
            $"\t\t{_selectedGear.type}\n" +
            $"\tBonus Health : {_selectedGear.bonusHealth}\n" +
            $"\tBonus Mana : {_selectedGear.bonusMana}\n" +
            $"\tBonus Attack : {_selectedGear.bonusAttack}\n" +
            $"\tBonus Defense : {_selectedGear.bonusDefense}\n" +
            $"\tBonus Intelligence : {_selectedGear.bonusIntelligence}\n" +
            $"\tBonus Agility : {_selectedGear.bonusAgility}\n" +
            $"\tBonus Luck : {_selectedGear.bonusLuck} \n");

    }


    public void DisplayGearInventory(string[] options, int selectedIndex)
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

    /*    static void Main(string[] args)
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
        }*/

}
 
}