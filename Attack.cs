namespace ASCIIFantasy
{
    public class Attack
    {
        private string attack_name;
        private int cost = 0;
        private static Random rnd = new Random();

        public Attack(string name)
        {
            attack_name = name;
            if (attack_name == "Heal") cost = 5;
            if (attack_name == "Bulk_up") cost = 20;
            else if (attack_name == "Fireball") cost = 7;
            else if (attack_name == "Bookworm") cost = 20;
            else if (attack_name == "Evasion") cost = 10;
            else if (attack_name == "Luckier") cost = 10;
        }

        /*Calls the differents functions needed for the differents attacks.*/
        public void Attacking(Character attacker, Character receiver)
        {

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
        }

        /*Applies the differents attack calculations and then prints the result.*/
        private void AttackToString(string name, Character attacker, Character receiver)
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

        public int HealToString(string name, Character attacker, List<Character> listCharacters)
        {
            int mana = attacker.GetStats().GetActualMana();
            bool crit = IsCriticalHit(attacker.GetStats().GetLuck());
            int value = rnd.Next(attacker.GetStats().GetIntel() + 1) + 4;
            if ((mana - cost) >= 0)
            {

                Console.WriteLine(" Who do you want to heal ?");
                Console.WriteLine(" 0) Return");
                for(int i = 0; i < listCharacters.Count; i++)
                {
                    Console.WriteLine(" " + (i+1) + ") " + listCharacters[i].GetName() + "    Health: " + listCharacters[i].GetStats().GetActualHealth() + "/" + listCharacters[i].GetStats().GetMaxHealth());
                }
                int choix = 0;
                if (int.TryParse(Console.ReadLine(), out choix))
                {
                    choix=choix-1;
                    if (choix == -1)
                    {
                        return 0;
                    }
                    else if (choix >= 0 && choix < listCharacters.Count)
                    {
                        Console.Clear();
                        Console.WriteLine($" {attacker.GetName()} used Heal");
                        if (crit)
                        {
                            value = value * 2;
                            Console.WriteLine($" Lucky critical ! {attacker.GetName()} healed {value} hp to {listCharacters[choix].GetName()}!");
                        }
                        else
                        {
                            Console.WriteLine($" {attacker.GetName()} healed {value} hp to {listCharacters[choix].GetName()}");
                        }
                        attacker.GetStats().IncrementMana(-cost);
                        listCharacters[choix].GetStats().IncrementHealth(value);
                        return 1;
                    }
                    else
                    {
                        Console.WriteLine("Invalid choice");
                        return 0;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid choice");
                    return 0;
                }
            }
            else
            {
                Console.WriteLine($" {attacker.GetName()} tried using {name} but forgot to look at his mana");
                Console.WriteLine($" {attacker.GetName()} lost his turn because of that...");
                return 1;
            }
        }

        // Verifies if the attack is a critical hit.
        private bool IsCriticalHit(int luck)
        {
            return rnd.Next(100) + 1 <= luck;
        }

        // Verifies if the receiver of the attack dodged.
        private bool IsDodged(int agility)
        {
            return rnd.Next(100) + 1 <= agility;
        }

        public int GetCost()
        {
            return cost;
        }

        private void BuffingToString(string name, Character attacker, Character receiver)
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

        private void FireballToString(string name, Character attacker, Character receiver)
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
    }
}