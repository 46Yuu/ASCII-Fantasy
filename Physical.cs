using System;
using ASCIIFantasy;

namespace ASCIIFantasy
{
    public class Physical : Attack
    {
        public Physical() : base("Melee")
        {
            this.cost = 0;
            this.type = AttackType.Physical;
            this.element = AttackElement.Neutral;
        }

        public override void Use(Character attacker, Character receiver)
        {
            int damage = rnd.Next(attacker.GetStats().GetAttack() + 1);
            bool crit = IsCriticalHit(attacker.GetStats().GetLuck());
            bool dodged = IsDodged(receiver.GetStats().GetAgility());
            Console.WriteLine($" {attacker.GetName()} used {attack_name}");

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
    }
}
