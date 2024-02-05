using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ASCIIFantasy
{
    public class Combat
    {
        public void FieldGame()
        {
            Console.Write("+");
            for (int i = 0; i < 73; i++)
                Console.Write("-");
            Console.Write("+");
            Console.WriteLine();
        }

        public void FieldPlayer1(Character c1)
        {
            for (int i = 0; i < 4; i++)
            {
                Console.WriteLine();
            }
            Console.WriteLine("\t\t\t\t" + c1.GetName() + "\n\t");
            c1.GetStats().ShowHealth();
            Console.Write("\t");
            c1.GetStats().ShowMana();
            Console.WriteLine("\n\n");
        }

        public void FieldPlayer2(Character c2)
        {
            Console.WriteLine();
            Console.WriteLine("\t\t\t\t" + c2.GetName() + "\n\t");
            c2.GetStats().ShowHealth();
            Console.Write("\t");
            c2.GetStats().ShowMana();
            Console.WriteLine("\n\n");
            for (int i = 0; i < 4; i++)
            {
                Console.WriteLine();
            }
        }

        public void FieldSetup(int turn, List<Character> listCharacters, List<Character> listEnemies)
        {
            FieldGame();
            FieldPlayer2(listEnemies[0]);
            FieldPlayer1(listCharacters[0]);
            FieldGame();
        }

        public int MeleeAttack(int turn, List<Character> listCharacters, List<Character> listEnemies)
        {
            if (turn == 0)
            {
                Console.Clear();
                listCharacters[0].GetAttack("Melee").Attacking(listCharacters[0], listEnemies[0]);
                Console.WriteLine(" End of " + listCharacters[0].GetName() + "'s turn");
            }
            else
            {
                listEnemies[0].GetAttack("Melee").Attacking(listEnemies[0], listCharacters[0]);
                Console.WriteLine(" End of " + listCharacters[0].GetName() + "'s turn");
            }
            return turn == 1 ? 0 : 1;
        }

        public int SpellChoice(int turn, List<Character> listCharacters, List<Character> listEnemies)
        {
            int length = listCharacters[0].GetListSpells().Count;
            string[] options = new string[length+1];
            options[0] = "Return";
            int selectedIndex = 0;
            List<string> spells = listCharacters[0].GetListSpells(); ;
            List<int> spellsCost = listCharacters[0].GetListCost();
            for (int i = 0; i < length; i++)
            {
                options[i+1] = (spells[i] + " , Cost : " + spellsCost[i] + "mana");
            }
            while (turn == 0)
            {
                DisplayPlayerChoice(turn, listCharacters, listEnemies, options, selectedIndex);

                ConsoleKeyInfo keyInfo = Console.ReadKey();
                Console.Clear();

                if (keyInfo.Key == ConsoleKey.Enter)
                {
                    (turn, selectedIndex) = SpellCharacterChoice(turn, listCharacters, selectedIndex,spells);
                    if (selectedIndex == 0)
                        break;
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
            return turn;

        }
        public (int, int) SpellCharacterChoice(int turn, List<Character> listCharacters, int selectedIndex,List<string> spells)
        {
            if (selectedIndex == 0)
            {
                Console.WriteLine(" " + listCharacters[0].GetName() + " return to action choice");
                return (turn, selectedIndex);
            }
            else if (selectedIndex < listCharacters[0].GetListSpells().Count)
            {
                string spellTmp = spells[selectedIndex];
                //execution du sort;
                Console.Clear();
                listCharacters[0].GetAttack(spellTmp).Attacking(listCharacters[0], listCharacters[1]);
                Console.WriteLine(" End of " + listCharacters[turn].GetName() + "'s turn");
                return (turn == 1 ? 0 : 1, selectedIndex);
            }
            else
            {
                Console.WriteLine(" Not a valid number");
                return (turn, selectedIndex);
            }
        }
        public (int,int) ChangeCharacterChoice(int turn, List<Character> listCharacters, int selectedIndex)
        {
            if (selectedIndex == 0)
            {
                Console.WriteLine(" " + listCharacters[0].GetName() + " return to action choice");
                return (turn,selectedIndex);
            }
            else if (selectedIndex < listCharacters.Count)
            {
                Console.Clear();
                Console.WriteLine(" " + listCharacters[0].GetName() + " changed to " + listCharacters[selectedIndex].GetName());
                Character temp = listCharacters[0];
                listCharacters[0] = listCharacters[selectedIndex];
                listCharacters[selectedIndex] = temp;
                return (turn == 1 ? 0 : 1, selectedIndex);
            }
            else
            {
                Console.WriteLine(" Not a valid number");
                return (turn, selectedIndex);
            }
        }
        public int ChangeCharacter(int turn, List<Character> listCharacters, List<Character> listEnemies)
        {
            string[] options = new string[listCharacters.Count];
            options[0] = "Return";
            int selectedIndex = 0;
            for (int i = 1; i < listCharacters.Count; i++)
            {
                options[i] = listCharacters[i].GetName();
            }
            while (turn == 0 )
            {
                DisplayPlayerChoice(turn, listCharacters, listEnemies, options, selectedIndex);

                ConsoleKeyInfo keyInfo = Console.ReadKey();
                Console.Clear();

                if (keyInfo.Key == ConsoleKey.Enter)
                {
                    (turn, selectedIndex) = ChangeCharacterChoice(turn, listCharacters, selectedIndex);
                    if (selectedIndex == 0)
                        break;
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
            return turn;
        }

        public void DisplayPlayerChoice(int turn, List<Character> listCharacters, List<Character> listEnemies, string[] options, int selectedIndex)
        {
            this.FieldSetup(turn, listCharacters, listEnemies);
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

        public int PlayerBaseChoice(int turn,List<Character> listCharacters, List<Character> listEnemies, int selectedIndex)
        {
            switch (selectedIndex)
            {
                case 0:
                    turn = MeleeAttack(turn, listCharacters, listEnemies);
                    return turn;
                case 1:
                    turn = SpellChoice(turn, listCharacters, listEnemies);
                    return turn;
                case 2:
                    if (turn == 0)
                        Console.Clear();
                    Console.WriteLine(listCharacters[0].ToString());
                    return turn;
                case 3:
                    turn = ChangeCharacter(turn, listCharacters, listEnemies);
                    return turn;
                default:
                    Console.WriteLine(" Not a valid number");
                    return turn;
            }
        }
        public int ChoicePlayer(int turn, List<Character> listCharacters, List<Character> listEnemies)
        {
            Console.CursorVisible = false;
            string[] options = { "Attack", "Spells", "Stats", "Change Character" };
            int selectedIndex = 0;

            while (turn == 0)
            {
                DisplayPlayerChoice(turn, listCharacters, listEnemies, options, selectedIndex);

                ConsoleKeyInfo keyInfo = Console.ReadKey();
                Console.Clear();

                if (keyInfo.Key == ConsoleKey.Enter)
                {
                    turn = PlayerBaseChoice(turn, listCharacters, listEnemies, selectedIndex);
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
            return turn;
        }

        public int ChoiceEnemy(int turn, List<Character> listCharacters, List<Character> listEnemies)
        {
            int choice = 0;
            Random rnd = new Random();
            choice = rnd.Next(1, 3);
            switch (choice)
            {
                case 1:
                    turn = MeleeAttack(turn, listCharacters, listEnemies);
                    return turn;
                case 2:
                    turn = SpellChoiceEnemy(turn, listCharacters, listEnemies);
                    return turn;
                default:
                    Console.WriteLine(" Not a valid number");
                    return turn;
            }
        }

        public int SpellChoiceEnemy(int turn, List<Character> listCharacters, List<Character> listEnemies)
        {
            int choixspell = 0;
            List<string> spells;
            List<int> spellsCost;
            string spellTmp = "";
            Random rnd = new Random();
            spells = listEnemies[0].GetListSpells();
            spellsCost = listEnemies[0].GetListCost();
            choixspell = rnd.Next(0, spells.Count);
            spellTmp = spells[choixspell];
            //execution du sort;
            listEnemies[0].GetAttack(spellTmp).Attacking(listEnemies[0], listCharacters[0]);
            Console.WriteLine(" End of " + listEnemies[0].GetName() + "'s turn");
            return turn == 1 ? 0 : 1;
        }


        static void Main(string[] args)
        {
            Combat combat = new Combat();
            Character player = new Character("Player", 100, 100, 10, 10, 10, 10, 10);
            Character player2 = new Character("VICTROR", 100, 100, 10, 10, 10, 10, 10);
            Character enemy = new Character("Enemy", 50, 50, 5, 5, 5, 5, 5);
            List<Character> listCharacters = new List<Character>();
            List<Character> listEnemies = new List<Character>();
            listCharacters.Add(player);
            listCharacters.Add(player2);
            listEnemies.Add(enemy);
            player.AddAttack("Fireball");
            player.AddAttack("Bulk_up");
            enemy.AddAttack("Fireball");
            enemy.AddAttack("Bulk_up");
            int turn = 0;
            int winner = 0;
            do
            {
                if (turn == 0)
                {
                    turn = combat.ChoicePlayer(turn, listCharacters, listEnemies);
                }
                else
                {
                    for (int i = 0; i < 25; i++)
                        Console.Write("-");
                    Console.WriteLine();
                    turn = combat.ChoiceEnemy(turn, listCharacters, listEnemies);
                }

            } while ((listCharacters[0].GetStats().GetActualHealth() > 0) && (listEnemies[0].GetStats().GetActualHealth() > 0));

            winner = (listCharacters[0].GetStats().GetActualHealth() == 0 ? 2 : 1);
            Console.WriteLine(" Player " + winner + " won !");
        }

    }

}
