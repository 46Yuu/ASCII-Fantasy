using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Numerics;

namespace ASCIIFantasy
{


    public class Character 
    {
        public string name { get; set;}
        protected Element element;
        protected StatsCharacter stats { get; set; }
        protected List<Attack> listAttack = new List<Attack>();
        protected Gear CharacterGear { get;}
        public bool isDead { get; set; } = false;

        public Character()
        {
            name = "";
            element = Element.Neutral;
            stats = new StatsCharacter();
        }

        public Character(string n,Element _element, int hp, int man, int atk, int def, int intel, int agi, int luc)
        {
            name = n;
            stats = new StatsCharacter(hp,man,atk,def,intel,agi,luc);
            element = _element;
            Physical melee = new Physical("Melee", Element.Neutral, 0, 0);
            listAttack.Add(melee);
        }

        public void AddAttack(Attack atk)
        {
            listAttack.Add(atk);
        }

        public Attack GetAttack(string name)
        {
            foreach (Attack attack in listAttack)
            {
                if (attack.attack_name == name)
                    return attack;
            }
            throw new Exception("Attack not found");
        }

        public StatsCharacter GetStats()
        {
            return stats;
        }

        public List<string> GetListSpells()
        {
            List<string> ret = new List<string>();
            foreach (Attack p in listAttack)
            {
                if (p.attack_name != "Melee")
                {
                    ret.Add(p.attack_name);
                }
            }
            return ret;
        }

        public List<int> GetListCost()
        {
            List<int> ret = new List<int>();
            foreach (Attack p in listAttack)
            {
                if (p.attack_name != "Melee")
                {
                    ret.Add(p.cost);
                }
            }
            return ret;
        }
       

        public override string ToString()
        {
            return $"Name: {name}\nHealth: {stats.actual_hp} / {stats.health}\nMana: {stats.actual_mana} / {stats.mana}\n" +
                $"Attack: {stats.attack}\nDefense: {stats.defense}\nAgility: {stats.agility}\nIntelligence: {stats.intelligence}\n" +
                $"Luck: {stats.luck}\n";

        }

        public Element GetElement() { return element; }

        //Main for testing
        /*static void Main()
        {
            Character player = new Character("Player", 100, 100, 10, 10, 10, 10, 10);
            Console.WriteLine(player.ToString());
            Console.WriteLine(player.GetListSpells()[0]);
            player.AddAttack("Fireball");
            Console.WriteLine(player.GetListSpells()[1]);

        }*/
    }
}
