using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASCIIFantasy
{
    public class Fireball : Spell
    { 
        public Fireball() : base("Fireball",Element.Fire,5,7) { }

        public override void Use(Character attacker, Character receiver)
        {
            base.Use(attacker, receiver);
        }

        public override int DamageCalculation(Character attacker, Character receiver)
        {

            int tmpDamage = rnd.Next(attacker.stats.intelligence+1) + power;
            if(receiver.GetElement() == Element.Grass )
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(" It's super effective !");
                Console.ResetColor();
                tmpDamage *= 2;
            }
            return tmpDamage;
        }
    }


}
