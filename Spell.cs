using System;
using ASCIIFantasy;

namespace ASCIIFantasy
{
    public class Spell : Attack
    {
        public Spell(string _name, Element _element,int _power, int _cost) : base(_name, _element, _power, _cost)
        {
            type = AttackType.Spell;
        }

        public override void Use(Character attacker, Character receiver)
        {
            
            int mana = attacker.stats.actual_mana;
            if ((mana - cost) >= 0)
            {
                bool crit = IsCriticalHit(attacker.stats.luck);
                bool dodged = IsDodged(receiver.stats.agility);
                Console.WriteLine($" {attacker.name} used {attack_name}");
                int damage = DamageCalculation(attacker, receiver);
                attacker.stats.IncrementMana(-cost);
                if (dodged)
                {
                    Console.WriteLine($" But {receiver.name} dodged !");
                }
                else if (crit)
                {
                    damage *= 2;
                    receiver.stats.IncrementHealth(-damage);
                    Console.BackgroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($" Critical hit ! {receiver.name} received {damage} damage!");
                    Console.ResetColor();
                }
                else
                {
                    receiver.stats.IncrementHealth(-damage);
                    Console.WriteLine($" {receiver.name} received {damage} damage!");
                }
            }
            else
            {
                Console.WriteLine($" {attacker.name} tried using {attack_name} but forgot to look at his mana");
                Console.WriteLine($" {attacker.name} lost his turn because of that...");
            }
            IsCharacterDead(receiver);
        }

        public virtual int DamageCalculation(Character attacker, Character receiver)
        {
            return rnd.Next(attacker.stats.intelligence+1) + power;
        }
    }
}
