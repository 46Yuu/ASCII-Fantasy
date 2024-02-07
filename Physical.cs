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
            int damage = rnd.Next(attacker.GetStats().attack + 1);
            bool crit = IsCriticalHit(attacker.GetStats().luck);
            bool dodged = IsDodged(receiver.GetStats().agility);
            Console.WriteLine($" {attacker.name} used {attack_name}");

            if (dodged)
            {
                Console.WriteLine($" But {receiver.name} dodged !");
            }
            else if (crit)
            {
                damage = damage * 2;
                receiver.GetStats().IncrementHealth(-damage);
                Console.WriteLine($" Critical hit ! {receiver.name} received {damage} damage!");
            }
            else
            {
                receiver.GetStats().IncrementHealth(-damage);
                Console.WriteLine($" {receiver.name} received {damage} damage!");
            }
            IsCharacterDead(receiver);
        }
    }
}
