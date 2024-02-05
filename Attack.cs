using ASCIIFantasy;

namespace ASCIIFantasy
{
    public enum AttackType 
    {
        Physical,
        Spell,
        Buff,
        Heal,
    }
    public enum AttackElement
    {
        Fire,
        Water,
        Grass,
        Neutral,
    }

    public class Attack
    {
        protected AttackType type;
        protected AttackElement element;
        protected string attack_name;
        protected int cost = 0;
        protected static Random rnd = new Random();

        public Attack(string name)
        {
            attack_name = name;
/*            if (attack_name == "Heal") cost = 5;
            if (attack_name == "Bulk_up") cost = 20;
            else if (attack_name == "Bookworm") cost = 20;
            else if (attack_name == "Evasion") cost = 10;
            else if (attack_name == "Luckier") cost = 10;*/
        }

        public string GetAttackName() { return attack_name; }

        /*Calls the differents functions needed for the differents attacks.*/
        public virtual void Use(Character attacker, Character receiver)//virtual Use()
        {
            /*switch(AttackType)
            {
                case AttackType.Physical:
                    PhysicalAttackToString(attack_name,attacker, receiver); break;
                case AttackType.Spell:
                    SpellAttackToString(attack_name,attacker,receiver); break;
                case AttackType.Buff:
                    BuffingToString(attack_name,attacker,receiver); break;
                case AttackType.Heal:
                   
            }*/
        }
      /*  {
           
            if (attack_name == "Melee")
            {
                AttackToString("Melee", attacker, receiver);
            }
            else if (attack_name == "Bulk_up")
            {
                BuffingToString("Bulk_up", attacker, receiver);
            }
            else if (attack_name == "Fireball")
            {
                FireballToString("Fireball", attacker, receiver);
            }
            else if (attack_name == "Bookworm")
            {
                BuffingToString("Bookworm", attacker, receiver);
            }
            else if (attack_name == "Evasion")
            {
                BuffingToString("Evasion", attacker, receiver);
            }
            else if (attack_name == "Luckier")
            {
                BuffingToString("Luckier", attacker, receiver);
            }
        }*/

        /*Applies the differents attack calculations and then prints the result.*/
        protected void PhysicalAttackToString(string name, Character attacker, Character receiver)
        {
            int damage = rnd.Next(attacker.GetStats().GetAttack() + 1);
            bool crit = IsCriticalHit(attacker.GetStats().GetLuck());
            bool dodged = IsDodged(receiver.GetStats().GetAgility());
            Console.WriteLine($" {attacker.GetName()} used {name}");

            if (dodged)
            {
                Console.WriteLine($" But {receiver.GetName()} dodged !");
            }
            else if (crit)
            {
                damage = damage * 2;
                receiver.GetStats().IncrementHealth(-damage);
                Console.WriteLine($" Critical hit ! {receiver.GetName()} received {damage} damage!");
            }
            else
            {
                receiver.GetStats().IncrementHealth(-damage);
                Console.WriteLine($" {receiver.GetName()} received {damage} damage!");
            }
        }

        private void SpellAttackToString(string name, Character attacker, Character receiver)
        {
            int damage = rnd.Next(attacker.GetStats().GetIntel() + 6) + 5;
            int mana = attacker.GetStats().GetActualMana();
            if ((mana - cost) >= 0)
            {
                bool crit = IsCriticalHit(attacker.GetStats().GetLuck());
                bool dodged = IsDodged(receiver.GetStats().GetAgility());
                Console.WriteLine($" {attacker.GetName()} used {name}");
                attacker.GetStats().IncrementMana(-cost);
                if (dodged)
                {
                    Console.WriteLine($" But {receiver.GetName()} dodged !");
                }
                else if (crit)
                {
                    damage = damage * 2;
                    receiver.GetStats().IncrementHealth(-damage);
                    Console.WriteLine($" Critical hit ! {receiver.GetName()} received {damage} damage!");
                }
                else
                {
                    receiver.GetStats().IncrementHealth(-damage);
                    Console.WriteLine($" {receiver.GetName()} received {damage} damage!");
                }
            }
            else
            {
                Console.WriteLine($" {attacker.GetName()} tried using {name} but forgot to look at his mana");
                Console.WriteLine($" {attacker.GetName()} lost his turn because of that...");
            }
        }

        public (int,int) HealCharacterSelected(int turn, List<Character> listCharacters, int selectedIndex)
        {
            if (selectedIndex == 0)
            {
                return (turn,0);
            }
            else if (selectedIndex > 0 && selectedIndex < listCharacters.Count)
            {
                bool crit = IsCriticalHit(listCharacters[0].GetStats().GetLuck());
                int value = rnd.Next(listCharacters[0].GetStats().GetIntel() + 1) + 4;
                Console.Clear();
                Console.WriteLine($" {listCharacters[0].GetName()} used Heal");
                if (crit)
                {
                    value = value * 2;
                    Console.WriteLine($" Lucky critical ! {listCharacters[0].GetName()} healed {value} hp to {listCharacters[selectedIndex].GetName()}!");
                }
                else
                {
                    Console.WriteLine($" {listCharacters[0].GetName()} healed {value} hp to {listCharacters[selectedIndex].GetName()}");
                }
                listCharacters[0].GetStats().IncrementMana(-cost);
                listCharacters[selectedIndex].GetStats().IncrementHealth(value);
                return (turn == 1 ? 0 : 1, selectedIndex);
            }
            else
            {
                Console.WriteLine("Invalid choice");
                return (turn,selectedIndex) ;
            }
        }

        public void DisplayListCharacter(List<Character> listCharacters, string[] options, int selectedIndex)
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
                if (i > 0 && i < listCharacters.Count)
                {
                    listCharacters[i].GetStats().ShowHealth();
                    listCharacters[i].GetStats().ShowMana();
                }
            }
        }

        public int HealToString(int turn, Character attacker, List<Character> listCharacters, Character enemy)
        {
            int mana = attacker.GetStats().GetActualMana();
            if ((mana - cost) >= 0)
            {
                string[] options = new string[listCharacters.Count];
                options[0] = "Return";
                int selectedIndex = 0;
                for (int i = 1; i < listCharacters.Count; i++)
                {
                    options[i] = listCharacters[i].GetName();
                }
                while (turn == 0)
                {
                    DisplayListCharacter(listCharacters,options, selectedIndex);

                    ConsoleKeyInfo keyInfo = Console.ReadKey();
                    Console.Clear();

                    if (keyInfo.Key == ConsoleKey.Enter)
                    {
                        (turn,selectedIndex) = HealCharacterSelected(turn, listCharacters, selectedIndex);
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
            else
            {
                Console.WriteLine($" {attacker.GetName()} tried using Heal but forgot to look at his mana");
                Console.WriteLine($" {attacker.GetName()} lost his turn because of that...");
                return turn;
            }
        }

        // Verifies if the attack is a critical hit.
        protected bool IsCriticalHit(int luck)
        {
            return rnd.Next(100) + 1 <= luck;
        }

        // Verifies if the receiver of the attack dodged.
        protected bool IsDodged(int agility)
        {
            return rnd.Next(100) + 1 <= agility;
        }

        public int GetCost()
        {
            return cost;
        }

        protected void BuffingToString(string name, Character attacker, Character receiver)
        {
            int mana = attacker.GetStats().GetActualMana();
            if ((mana - cost) >= 0)
            {
                Console.WriteLine($" {attacker.GetName()} used {name}");
                attacker.GetStats().IncrementMana(-cost);
                if (name == "Bulk_up")
                {
                    Console.WriteLine($" {attacker.GetName()} buffed by 8 points his strength stat!");
                    attacker.GetStats().IncrementAttack(8);
                }
                else if (name == "Bookworm")
                {
                    Console.WriteLine($" {attacker.GetName()} buffed by 8 points his intelligence stat!");
                    attacker.GetStats().IncrementIntel(8);
                }
                else if (name == "Evasion")
                {
                    Console.WriteLine($" {attacker.GetName()} buffed by 10 points his agility stat!");
                    attacker.GetStats().IncrementAgility(10);
                }
                else if (name == "Luckier")
                {
                    Console.WriteLine($" {attacker.GetName()} buffed by 5 points his luck stat!");
                    attacker.GetStats().IncrementLuck(5);
                }
            }
            else
            {
                Console.WriteLine($" {attacker.GetName()} tried using {name} but forgot to look at his mana");
                Console.WriteLine($" {attacker.GetName()} lost his turn because of that...");
            }
        }
        
    }
}