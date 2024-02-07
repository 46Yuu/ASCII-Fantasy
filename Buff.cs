using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ASCIIFantasy
{
    public class Buff : Attack
    {
        public Buff(string name, Element element, int power, int cost) : base(name, element, power, cost) 
        {
            type = AttackType.Buff;
        }
        //power = buff power in percentage
        public override void Use(Character attacker, Character receiver)
        {
            int mana = attacker.GetStats().actual_mana;
            if ((mana - cost) >= 0)
            {
                Console.WriteLine($" {attacker.name} used {attack_name}");
                attacker.GetStats().IncrementMana(-cost);
                BuffStats(attacker, receiver);
            }
            else
            {
                Console.WriteLine($" {attacker.name} tried using {attack_name} but forgot to look at his mana");
                Console.WriteLine($" {attacker.name} lost his turn because of that...");
            }
        }

        public virtual void BuffStats(Character attacker, Character receiver) { }

    }
}
