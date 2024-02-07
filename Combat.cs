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
            Console.WriteLine("\t\t\t\t" + c1.name + "\n\t");
            c1.GetStats().ShowHealth();
            Console.Write("\t");
            c1.GetStats().ShowMana();
            Console.WriteLine("\n\n");
        }

        public void FieldPlayer2(Character c2)
        {
            Console.WriteLine();
            Console.WriteLine("\t\t\t\t" + c2.name + "\n\t");
            c2.GetStats().ShowHealth();
            Console.Write("\t");
            c2.GetStats().ShowMana();
            Console.WriteLine("\n\n");
            for (int i = 0; i < 4; i++)
            {
                Console.WriteLine();
            }
        }

        public void FieldSetup(int turn, List<Character> listCharacters, Character enemy)
        {
            FieldGame();
            FieldPlayer2(enemy);
            FieldPlayer1(listCharacters[0]);
            FieldGame();
        }

        public int MeleeAttack(int turn, List<Character> listCharacters, Character enemy)
        {
            if (turn == 0)
            {
                Console.Clear();
                FieldGame();
                listCharacters[0].GetAttack("Melee").Use(listCharacters[0], enemy);
                Console.WriteLine(" End of " + listCharacters[0].name + "'s turn");
            }
            else
            {
                enemy.GetAttack("Melee").Use(enemy, listCharacters[0]);
                Console.WriteLine(" End of " + listCharacters[0].name + "'s turn");
            }
            return turn == 1 ? 0 : 1;
        }

        public int SpellChoice(int turn, List<Character> listCharacters, Character enemy)
        {
            List<string> spells = listCharacters[0].GetListSpells();
            List<int> spellsCost = listCharacters[0].GetListCost();
            int length = spells.Count;
            string[] options = new string[length+1];
            options[0] = "Return";
            int selectedIndex = 0;

            for (int i = 0; i < length; i++)
            {
                options[i+1] = (spells[i] + " , Cost : " + spellsCost[i] + "mana");
            }
            while (turn == 0)
            {
                DisplayPlayerChoice(turn, listCharacters, enemy, options, selectedIndex);

                ConsoleKeyInfo keyInfo = Console.ReadKey();
                Console.Clear();

                if (keyInfo.Key == ConsoleKey.Enter)
                {
                    (turn, selectedIndex) = SpellCharacterChoice(turn, listCharacters, enemy, selectedIndex,spells);
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
        public (int, int) SpellCharacterChoice(int turn, List<Character> listCharacters, Character enemy, int selectedIndex,List<string> spells)
        {
            if (selectedIndex == 0)
            {
                Console.WriteLine(" " + listCharacters[0].name + " return to action choice");
                return (turn, selectedIndex);
            }
            else if (selectedIndex-1 < spells.Count)
            {
                string spellTmp = spells[selectedIndex-1];
                //execution du sort;
                Console.Clear();
                FieldGame();
                AttackType attackType = listCharacters[0].GetAttack(spellTmp).type;
                if (attackType == AttackType.Heal)
                {
                    if (listCharacters[0].GetAttack(spellTmp) is Heal healAttack)
                    {
                        healAttack.UseHeal(turn, listCharacters[0], listCharacters);
                    }
                }
                else
                {
                    listCharacters[0].GetAttack(spellTmp).Use(listCharacters[0], enemy);
                }
                Console.WriteLine(" End of " + listCharacters[turn].name + "'s turn");
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
                Console.WriteLine(" " + listCharacters[0].name + " return to action choice");
                return (turn,selectedIndex);
            }
            else if (selectedIndex < listCharacters.Count)
            {
                Console.Clear();
                FieldGame();
                Console.WriteLine(" " + listCharacters[0].name + " changed to " + listCharacters[selectedIndex].name);
                Character temp = listCharacters[0];
                listCharacters[0] = listCharacters[selectedIndex];
                listCharacters[selectedIndex] = temp;
                listCharacters[0].GetStats().StoreInitialStats();
                listCharacters[selectedIndex].GetStats().RestoreInitialStats();
                return (turn == 1 ? 0 : 1, selectedIndex);
            }
            else
            {
                Console.WriteLine(" Not a valid number");
                return (turn, selectedIndex);
            }
        }
        public int ChangeCharacter(int turn, List<Character> listCharacters, Character enemy,bool forceChange = false)
        {
            List<string> options = new List<string>();
            if (!forceChange)
            {
                options.Add("Return");
            }
            int selectedIndex = 0;
            for (int i = 1; i < listCharacters.Count; i++)
            {
                if (!listCharacters[i].isDead)
                {
                    options.Add(listCharacters[i].name);
                }
            }
            while (turn == 0 )
            {
                DisplayPlayerChoiceWithHealth(turn, listCharacters, enemy, options, selectedIndex);

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
                            selectedIndex = (selectedIndex - 1 + options.Count) % options.Count;
                            break;
                        case ConsoleKey.DownArrow:
                            selectedIndex = (selectedIndex + 1) % options.Count;
                            break;
                    }
                }
            }
            return turn;
        }

        public void DisplayPlayerChoiceWithHealth(int turn, List<Character> listCharacters, Character enemy, List<string> options, int selectedIndex)
        {
            this.FieldSetup(turn, listCharacters, enemy);
            for (int i = 0; i < options.Count; i++)
            {
                if (i == selectedIndex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("> ");
                    Console.WriteLine(options[i]);
                    Console.ResetColor();
                }
                else
                {
                    Console.Write("  ");
                    Console.WriteLine(options[i]);
                }
                if (i > 0 && i < listCharacters.Count)
                {
                    listCharacters[i].GetStats().ShowHealth();
                    listCharacters[i].GetStats().ShowMana();
                }
            }
        }

        public void DisplayPlayerChoice(int turn, List<Character> listCharacters, Character enemy, string[] options, int selectedIndex)
        {
            this.FieldSetup(turn, listCharacters, enemy);
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

        public int PlayerBaseChoice(int turn,List<Character> listCharacters, Character enemy, int selectedIndex)
        {
            switch (selectedIndex)
            {
                case 0:
                    turn = MeleeAttack(turn, listCharacters, enemy);
                    return turn;
                case 1:
                    turn = SpellChoice(turn, listCharacters, enemy);
                    return turn;
                case 2:
                    if (turn == 0)
                        Console.Clear();
                    Console.WriteLine(listCharacters[0].ToString());
                    return turn;
                case 3:
                    turn = ChangeCharacter(turn, listCharacters, enemy);
                    return turn;
                default:
                    Console.WriteLine(" Not a valid number");
                    return turn;
            }
        }
        public int ChoicePlayer(int turn, List<Character> listCharacters, Character enemy)
        {
            Console.CursorVisible = false;
            string[] options = { "Attack", "Spells", "Stats", "Change Character" };
            int selectedIndex = 0;

            while (turn == 0)
            {
                DisplayPlayerChoice(turn, listCharacters, enemy, options, selectedIndex);

                ConsoleKeyInfo keyInfo = Console.ReadKey();
                Console.Clear();

                if (keyInfo.Key == ConsoleKey.Enter)
                {
                    turn = PlayerBaseChoice(turn, listCharacters, enemy, selectedIndex);
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

        public int ChoiceEnemy(int turn, List<Character> listCharacters, Character enemy)
        {
            int choice = 0;
            Random rnd = new Random();
            choice = rnd.Next(1, 3);
            switch (choice)
            {
                case 1:
                    turn = MeleeAttack(turn, listCharacters, enemy);
                    return turn;
                case 2:
                    turn = SpellChoiceEnemy(turn, listCharacters, enemy);
                    return turn;
                default:
                    Console.WriteLine(" Not a valid number");
                    return turn;
            }
        }

        public int SpellChoiceEnemy(int turn, List<Character> listCharacters, Character enemy)
        {
            int choixspell = 0;
            List<string> spells;
            List<int> spellsCost;
            string spellTmp = "";
            Random rnd = new Random();
            spells = enemy.GetListSpells();
            spellsCost = enemy.GetListCost();
            choixspell = rnd.Next(0, spells.Count);
            spellTmp = spells[choixspell];
            //execution du sort;
            enemy.GetAttack(spellTmp).Use(enemy, listCharacters[0]);
            Console.WriteLine(" End of " + enemy.name + "'s turn");
            return turn == 1 ? 0 : 1;
        }


        static void Main(string[] args)
        {
            Combat combat = new Combat();
            Character player = new Character("Player",Element.Neutral, 100, 100, 1, 10, 5, 10, 10);
            Character player2 = new Character("VICTROR",Element.Neutral, 100, 100, 10, 10, 10, 10, 10);
            Character enemy = new Character("Enemy",Element.Grass, 50, 50, 20, 5, 5, 5, 5);
            List<Character> listCharacters = new List<Character>();
            Spell fireball = new Fireball();
            Buff ryuMonsho = new RyuMonsho();
            Heal heal = new SmallHeal();
            listCharacters.Add(player);
            listCharacters.Add(player2);
            player.AddAttack(fireball);
            player.AddAttack(ryuMonsho);
            player2.AddAttack(heal);
            enemy.AddAttack(fireball);
            player.GetStats().StoreInitialStats();
            int turn = 0;
            int winner;
            bool stillCharactersAlive = true;
            do
            {
                if (turn == 0)
                {
                    turn = combat.ChoicePlayer(turn, listCharacters, enemy);
                }
                else
                {
                    for (int i = 0; i < 25; i++)
                        Console.Write("-");
                    Console.WriteLine();
                    turn = combat.ChoiceEnemy(turn, listCharacters, enemy);
                }
                stillCharactersAlive = false;
                foreach (Character p in listCharacters)
                {
                    if (!p.isDead)
                    {
                        stillCharactersAlive = true;
                        break;
                    }
                }
                if (listCharacters[0].isDead)
                {
                    combat.ChangeCharacter(turn, listCharacters, enemy, true);
                }

            } while (stillCharactersAlive && (enemy.GetStats().actual_hp > 0));
            winner = (enemy.GetStats().actual_hp > 0 ? 0 : 1);
            if(winner == 0)
            {
                Console.WriteLine($" {enemy.name} has been defeated !");
            }
            else
            {
                Console.WriteLine(" You lost !");
            }
        }

    }

}
