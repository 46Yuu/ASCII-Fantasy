using System;
using ASCIIFantasy;

namespace ASCIIFantasy
{
    public class Fireball : Attack
    {
        public Fireball() : base("Fireball")
        {
            this.cost = 7;
            this.type = AttackType.Spell;
            this.element = AttackElement.Fire;
        }

        public override void Use(Character attacker, Character receiver)
        {
            int damage = rnd.Next(attacker.GetStats().GetIntel() + 6) + 5;
            int mana = attacker.GetStats().GetActualMana();
            if ((mana - cost) >= 0)
            {
                bool crit = IsCriticalHit(attacker.GetStats().GetLuck());
                bool dodged = IsDodged(receiver.GetStats().GetAgility());
                Console.WriteLine($" {attacker.GetName()} used {attack_name}");
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
                Console.WriteLine($" {attacker.GetName()} tried using {attack_name} but forgot to look at his mana");
                Console.WriteLine($" {attacker.GetName()} lost his turn because of that...");
            }

        }
    }
}
