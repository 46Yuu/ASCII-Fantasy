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
                Console.Write("=");
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
            Console.Clear();
            if (turn == 0)
            {
                listCharacters[0].GetAttack("Melee").Attacking(listCharacters[0], listEnemies[0]);
            }
            else
            {
                listEnemies[0].GetAttack("Melee").Attacking(listEnemies[0], listCharacters[0]);
            }
            Console.WriteLine(" End of " + listCharacters[turn].GetName() + "'s turn");
            return turn == 1 ? 0 : 1;
        }

        public int SpellChoice(int turn, List<Character> listCharacters, List<Character> listEnemies)
        {
            int choixspell = 0;
            List<string> spells;
            List<int> spellsCost;
            string spellTmp = "";
            if (turn == 0)
            {
                Console.WriteLine(" Choose your spell\n 0) Return\n ");
                spells = listCharacters[0].GetListSpells();
                spellsCost = listCharacters[0].GetListCost();
            }
            else
            {
                spells = listEnemies[0].GetListSpells();
                spellsCost = listEnemies[0].GetListCost();
            }
            for (int i = 0; i < spells.Count; i++)
            {
                Console.WriteLine(" " + (i + 1) + ") " + spells[i] + " , Cost : " + spellsCost[i] + "mana\n ");
            }
            string input = Console.ReadLine();
            if (turn == 1)
            {
                choixspell = rnd.Next(0, spells.Count);
                spellTmp = spells[choixspell];
                //execution du sort;
                listEnemies[0].GetAttack(spellTmp).Attacking(listEnemies[0], listCharacters[0]);
                Console.WriteLine(" End of " + listEnemies[0].GetName() + "'s turn");
                return turn == 1 ? 0 : 1;
            }
            if (int.TryParse(input, out choixspell))
            {
                choixspell -= 1;
                if (choixspell >= 0 && choixspell < spells.Count)
                {
                    spellTmp = spells[choixspell];
                    //execution du sort;
                    listCharacters[0].GetAttack(spellTmp).Attacking(listCharacters[0], listCharacters[1]);
                    Console.WriteLine(" End of " + listCharacters[turn].GetName() + "'s turn");
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
        public int ChoicePlayer(int turn, List<Character> listCharacters, List<Character> listEnemies)
        {
            int choice = 0;
            string input= "";
            if(turn == 0)
            {
                Console.WriteLine(" What are you going to do ? \n 1) Attack \n 2) Spells\n 3) Stats");
                input = Console.ReadLine();
                Console.WriteLine();
                if (int.TryParse(input, out choice))
                {
                    /*Switch depending on the user choice.*/
                    switch (choice)
                    {
                        case 1:
                            turn = MeleeAttack(turn, listCharacters);
                            return turn;
                        case 2:
                            turn = SpellChoice(turn, listCharacters);
                            return turn;
                        case 3:
                            if (turn + 1 == 1)
                                Console.WriteLine(listCharacters[0].ToString());
                            else
                                Console.WriteLine(listCharacters[1].ToString());
                            return turn;
                        default:
                            Console.WriteLine(" Not a valid number");
                            return turn;
                    }
                }
            }           
            
        static void Main(string[] args)
        {
            Combat combat = new Combat();
            Character player = new Character("Player", 100, 100, 10, 10, 10, 10, 10);
            Character enemy = new Character("Enemy", 50, 50, 5, 5, 5, 5, 5);
            List<Character> listCharacters = new List<Character>();
            List<Character> listEnemies = new List<Character>();
            listCharacters.Add(player1);
            listCharacters.Add(player2);
            player1.AddAttack("Fireball");
            player1.AddAttack("Bulk_up");
            player2.AddAttack("Fireball");
            int turn = 0;
            int winner = 0;
            do
            {
                combat.FieldSetup(turn, listCharacters, listEnemies);
                turn = combat.ChoicePlayer(turn, listCharacters, listEnemies);
            } while ((listCharacters[0].GetStats().GetActualHealth() > 0) && (listEnemies[0].GetStats().GetActualHealth() > 0));

            winner = (listCharacters[0].GetStats().GetActualHealth() == 0 ? 2 : 1);
            Console.WriteLine(" Player " + winner + " won !");
        }

    }
   
}
