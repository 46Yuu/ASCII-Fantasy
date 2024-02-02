using System;
using System.Collections.Generic;
using System.Linq;
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
            Console.WriteLine("\t\t" + c1.GetName());
            Console.Write("\t");
            c1.GetStats().ShowHealth();
            c1.GetStats().ShowMana();
            Console.WriteLine("\n\n");
        }

        public void FieldPlayer2(Character c2)
        {
            Console.WriteLine();
            for (int i = 0; i < 7; i++)
            {
                Console.Write("\t  ");
            }
            Console.WriteLine(c2.GetName());
            for (int i = 0; i < 6; i++)
            {
                Console.Write("\t");
            }
            c2.GetStats().ShowHealth();
            c2.GetStats().ShowMana();
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
            int choixspell = 0;
            List<string> spells;
            List<int> spellsCost;
            string spellTmp = "";
            Console.WriteLine(" Choose your spell\n 0) Return\n ");
            spells = listCharacters[0].GetListSpells();
            spellsCost = listCharacters[0].GetListCost();
            for (int i = 0; i < spells.Count; i++)
            {
                Console.WriteLine(" " + (i + 1) + ") " + spells[i] + " , Cost : " + spellsCost[i] + "mana\n ");
            }
            if (int.TryParse(Console.ReadLine(), out choixspell))
            {
                choixspell -= 1;
                if (choixspell >= 0 && choixspell < spells.Count)
                {
                    spellTmp = spells[choixspell];
                    //execution du sort;
                    Console.Clear();
                    listCharacters[0].GetAttack(spellTmp).Attacking(listCharacters[0], listEnemies[0]);
                    if(spellTmp == "Heal")
                    {
                        listCharacters[0].GetAttack(spellTmp).HealToString("Heal", listCharacters[0], listCharacters);
                    }
                    Console.WriteLine(" End of " + listCharacters[0].GetName() + "'s turn");
                    return turn == 1 ? 0 : 1;
                }
                else if (choixspell == -1)
                {
                    Console.WriteLine(listCharacters[0].GetName() + " return to action choice");
                    return turn;
                }
                else
                {
                    Console.WriteLine(" Not a valid number");
                    return turn;
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a number.");
                return turn;
            }
        }

        public int ChangeCharacter(int turn, List<Character> listCharacters)
        {
            int choice = 0;
            Console.WriteLine(" Choose your character\n 0) Return\n ");
            for (int i = 1; i < listCharacters.Count; i++)
            {
                Console.WriteLine(" " + i + ") " + listCharacters[i].GetName());
            }
            if (int.TryParse(Console.ReadLine(), out choice))
            {
                if (choice == 0)
                {
                    Console.WriteLine(listCharacters[0].GetName() + " return to action choice");
                    return turn;
                }
                else if (choice < listCharacters.Count)
                {
                    Console.Clear();
                    Console.WriteLine(listCharacters[0].GetName() + " changed to " + listCharacters[choice].GetName());
                    Character temp = listCharacters[0];
                    listCharacters[0] = listCharacters[choice];
                    listCharacters[choice] = temp;
                    return turn == 1 ? 0 : 1;
                }
                else
                {
                    Console.WriteLine(" Not a valid number");
                    return turn;
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a number.");
                return turn;
            }
        }

        public int ChoicePlayer(int turn, List<Character> listCharacters, List<Character> listEnemies)
        {
            int choice = 0;
            string input = "";
            Console.WriteLine(" What are you going to do ? \n 1) Attack \n 2) Spells\n 3) Stats\n 4) Change Character\n");
            if (int.TryParse(Console.ReadLine(), out choice))
            {
                /*Switch depending on the user choice.*/
                switch (choice)
                {
                    case 1:

                        turn = MeleeAttack(turn, listCharacters, listEnemies);
                        return turn;
                    case 2:
                        turn = SpellChoice(turn, listCharacters, listEnemies);
                        return turn;
                    case 3:
                        if (turn == 0)
                            Console.Clear();
                            Console.WriteLine(listCharacters[0].ToString());
                        return turn;
                    case 4:
                        turn = ChangeCharacter(turn, listCharacters);
                        return turn;
                    default:
                        Console.WriteLine(" Not a valid number");
                        return turn;
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a number.");
                return turn;
            }
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
            player.AddAttack("Heal");
            enemy.AddAttack("Fireball");
            enemy.AddAttack("Bulk_up");
            int turn = 0;
            int winner = 0;
            do
            {
                if (turn == 0)
                {
                    combat.FieldSetup(turn, listCharacters, listEnemies);
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
