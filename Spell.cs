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
            
            int mana = attacker.GetStats().actual_mana;
            if ((mana - cost) >= 0)
            {
                bool crit = IsCriticalHit(attacker.GetStats().luck);
                bool dodged = IsDodged(receiver.GetStats().agility);
                Console.WriteLine($" {attacker.name} used {attack_name}");
                int damage = DamageCalculation(attacker, receiver);
                attacker.GetStats().IncrementMana(-cost);
                if (dodged)
                {
                    Console.WriteLine($" But {receiver.name} dodged !");
                }
                else if (crit)
                {
                    damage *= 2;
                    receiver.GetStats().IncrementHealth(-damage);
                    Console.BackgroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($" Critical hit ! {receiver.name} received {damage} damage!");
                    Console.ResetColor();
                }
                else
                {
                    receiver.GetStats().IncrementHealth(-damage);
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
            return rnd.Next(attacker.GetStats().intelligence+1) + power;
        }
    }
}
