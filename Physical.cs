using System;
using System.Xml.Linq;
using ASCIIFantasy;

namespace ASCIIFantasy
{
    public class Physical : Attack
    {
        public Physical(string _name, Element _element, int _power, int _cost) : base(_name, _element, _power, _cost)
        {
            this.type = AttackType.Physical;
        }

        public override void Use(Character attacker, Character receiver)
        {
            int damage = rnd.Next(attacker.stats.attack + 1);
            bool crit = IsCriticalHit(attacker.stats.luck);
            bool dodged = IsDodged(receiver.stats.agility);
            Console.WriteLine($" {attacker.name} used {attack_name}");

            if (dodged)
            {
                Console.WriteLine($" But {receiver.name} dodged !");
            }
            else if (crit)
            {
                damage = damage * 2;
                damage -= receiver.stats.defense;
                receiver.stats.IncrementHealth(-damage);
                Console.BackgroundColor = ConsoleColor.Yellow;
                Console.WriteLine($" Critical hit ! {receiver.name} received {damage} damage!");
            }
            else
            {
                damage -= receiver.stats.defense;
                receiver.stats.IncrementHealth(-damage);
                Console.WriteLine($" {receiver.name} received {damage} damage!");
            }
            IsCharacterDead(receiver);
        }
    }
}
