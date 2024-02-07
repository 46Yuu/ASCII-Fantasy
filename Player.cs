﻿using ASCIIFantasy;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace ASCIIFantasy
{
    public class Player : Character
    {
        public List<Character> listCharacters { get; set; }
        public Inventory inventory{ get; set; }
        int selectedCharacterIndex;

        public Player()
        {
            listCharacters = new();
            inventory = new();
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
            string[] options = new string[this.listCharacters.Count + 1];
            options[0] = "Return";
            int selectedIndex = 0;
            selectedCharacterIndex = 0;
            bool isChoiceDone = false;
            for (int i = 0; i < listCharacters.Count; i++)
            {
                options[i + 1] = listCharacters[i].name;
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
                        selectedCharacterIndex = selectedIndex - 1;
                        SelectCharacterMenu(listCharacters[selectedIndex - 1]);
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
            int optionLength = _selected.GetGear().pieces.Count + _selected.stats.statsList.Count;
            string[] options = new string[optionLength + 1];
            int selectedIndex = 0;
            options[0] = "Return";
            bool isChoiceDone = false;
            for (int i = 0; i < optionLength; i++)
            {
                if (i < _selected.GetGear().pieces.Count)
                {
                    if (_selected.GetGear().pieces[i].isNull == false)
                    {
                        options[i + 1] = $"{_selected.GetGear().pieces[i].type.ToString()} : {_selected.GetGear().pieces[i].gearName}";
                    }
                    else
                    {
                        options[i + 1] = $"{_selected.GetGear().pieces[i].type.ToString()} : {_selected.GetGear().pieces[i].gearName} No Gear Equiped";
                    }
                }
                else
                {
                    switch (i)
                    {
                        case 5:
                            options[i + 1] = $"Health : {_selected.stats.statsList[i - 5]} (+ {_selected.stats.GetBonusHealth()}) : {_selected.stats.statsList[i - 5] + _selected.stats.GetBonusHealth()}";
                            break;
                        case 6:
                            options[i + 1] = $"Mana : {_selected.stats.statsList[i - 5]} (+{_selected.stats.GetBonusMana()}) : {_selected.stats.statsList[i - 5] + _selected.stats.GetBonusMana()}";
                            break;
                        case 7:
                            options[i + 1] = $"Attack : {_selected.stats.statsList[i - 5]} (+{_selected.stats.GetBonusAttack()}) : {_selected.stats.statsList[i - 5] + _selected.stats.GetBonusAttack()}";
                            break;
                        case 8:
                            options[i + 1] = $"Defense : {_selected.stats.statsList[i - 5]} (+{_selected.stats.GetBonusDefense()}) : {_selected.stats.statsList[i - 5] + _selected.stats.GetBonusDefense()}";
                            break;
                        case 9:
                            options[i + 1] = $"Intelligence : {_selected.stats.statsList[i - 5]} (+{_selected.stats.GetBonusIntelligence()}) : {_selected.stats.statsList[i - 5] + _selected.stats.GetBonusIntelligence()}";
                            break;
                        case 10:
                            options[i + 1] = $"Agility : {_selected.stats.statsList[i - 5]} (+{_selected.stats.GetBonusAgility()}) : {_selected.stats.statsList[i - 5] + _selected.stats.GetBonusAgility()}";
                            break;
                        case 11:
                            options[i + 1] = $"Luck : {_selected.stats.statsList[i - 5]} (+{_selected.stats.GetBonusLuck()}) : {_selected.stats.statsList[i - 5] + _selected.stats.GetBonusLuck()}";
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
                    if (selectedIndex <= 6 && selectedIndex > 0)
                    {
                        SelectGearToEquip(_selected.GetGear().pieces[selectedIndex - 1].type);
                    }
                    switch (selectedIndex)
                    {
                        case 0:
                            SelectCharacter();
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
            List<GearPiece> list = inventory.listGearInventory;
            List<string> options = new();
            List<int> indexes = new();
            indexes.Add(-1);
            options.Add("Return\n");
            int selectedIndex = 0;
            bool isChoiceDone = false;
            int temp = 1;
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].type == _selectedGear && list[i].isEquiped == false)
                {
                    options.Add(list[i].gearName);
                    indexes.Add(i);
                    temp++;
                }
            }
            while (!isChoiceDone)
            {
                DisplayGearChoice(list, options, selectedIndex);

                ConsoleKeyInfo keyInfo = Console.ReadKey();
                Console.Clear();

                if (keyInfo.Key == ConsoleKey.Enter)
                {
                    if (selectedIndex == 0)
                    {
                        isChoiceDone = true;
                        SelectCharacterMenu(listCharacters[selectedIndex]);
                    }
                    else
                    {
                        listCharacters[selectedCharacterIndex].Equip(list[indexes[selectedIndex]]);
                        SelectCharacterMenu(listCharacters[selectedCharacterIndex]);
                    }
                }
                else
                {
                    switch (keyInfo.Key)
                    {
                        case ConsoleKey.UpArrow:
                            selectedIndex = (selectedIndex - 1 + options.Count) % options.Count;
                            break;
                        case ConsoleKey.DownArrow:
                            selectedIndex = (selectedIndex + 1) % options.Count;
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
        public void DisplayGearChoice(List<GearPiece> listGear, List<string> options, int selectedIndex)
        {
            for (int i = 0; i < options.Count; i++)
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

        /*  static void Main(string[] args)
          {
              Character player1 = new Character("Player1", 100, 100, 10, 10, 10, 10, 10);
              Character player2 = new Character("Player2", 100, 100, 10, 10, 10, 10, 10);
              Player player = new Player();
              GearList.CreateInstance();
              player.listCharacters.Add(player1);
              player.listCharacters.Add(player2);
              player2.Equip(GearList.instance.listGear[0]);
              player2.Equip(GearList.instance.listGear[1]);
              player2.Equip(GearList.instance.listGear[2]);
              player1.Equip(GearList.instance.listGear[3]);
              player1.Equip(GearList.instance.listGear[4]);

              player.SelectCharacter();
          }*/

    }
}