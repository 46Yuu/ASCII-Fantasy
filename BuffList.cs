using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASCIIFantasy
{
    public class BulkUp : Buff
    {
        public BulkUp() : base("Bulk Up", Element.Neutral, 10, 20) { }

        public override void Use(Character attacker, Character receiver)
        {
            base.Use(attacker, receiver);
        }

        public override void BuffStats(Character attacker, Character receiver)
        {
            int ptsOfBuff = (attacker.GetStats().attack * power) / 100;
            Console.WriteLine($" {attacker.name} buffed by "+ptsOfBuff+" points his attack stat!");
            attacker.GetStats().IncrementAttack(ptsOfBuff);
        }
    }

    public class RyuMonsho : Buff
    {
        public RyuMonsho() : base("Ryu Monsho", Element.Neutral, 30, 10) { }

        public override void Use(Character attacker, Character receiver)
        {
            base.Use(attacker, receiver);
        }

        public override void BuffStats(Character attacker, Character receiver)
        {
            int ptsOfBuff = power;
            Console.WriteLine($" {attacker.name} buffed by " + ptsOfBuff + " points his attack stat!");
            attacker.GetStats().IncrementAttack(ptsOfBuff);
        }
    }

    public class BookWorm : Buff
    {
        public BookWorm() : base("BookWorm", Element.Neutral, 10, 20) { }

        public override void Use(Character attacker, Character receiver)
        {
            base.Use(attacker, receiver);
        }

        public override void BuffStats(Character attacker, Character receiver)
        {
            int ptsOfBuff = (attacker.GetStats().intelligence * power) / 100;
            Console.WriteLine($" {attacker.name} buffed by " + ptsOfBuff + " points his intelligence stat!");
            attacker.GetStats().IncrementAttack(ptsOfBuff);
        }
    }

    public class Evasion : Buff
    {
        public Evasion() : base("Evasion", Element.Neutral, 10, 15) { }

        public override void Use(Character attacker, Character receiver)
        {
            base.Use(attacker, receiver);
        }

        public override void BuffStats(Character attacker, Character receiver)
        {
            int ptsOfBuff = (attacker.GetStats().agility * power) / 100;
            Console.WriteLine($" {attacker.name} buffed by " + ptsOfBuff + " points his agility stat!");
            attacker.GetStats().IncrementAttack(ptsOfBuff);
        }
    }

    public class Luckier : Buff
    {
        public Luckier() : base("Luckier", Element.Neutral, 5, 10) { }

        public override void Use(Character attacker, Character receiver)
        {
            base.Use(attacker, receiver);
        }

        public override void BuffStats(Character attacker, Character receiver)
        {
            int ptsOfBuff = (attacker.GetStats().luck * power) / 100;
            Console.WriteLine($" {attacker.name} buffed by " + ptsOfBuff + " points his luck stat!");
            attacker.GetStats().IncrementAttack(ptsOfBuff);
        }
    }

}
