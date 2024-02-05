using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Numerics;

namespace ASCIIFantasy
{
    public class Character 
    {
        protected string name;
        protected StatsCharacter stats { get; set; }
        protected List<Attack> listAttack = new List<Attack>();
        protected Gear CharacterGear { get;}

        public Character()
        {
            name = "";
            stats = new StatsCharacter();
        }

        public Character(string n, int hp, int man, int atk, int def, int intel, int agi, int luc)
        {
            name = n;
            stats = new StatsCharacter(hp,man,atk,def,intel,agi,luc);
            Physical melee = new Physical();
            listAttack.Add(melee);
        }

        public void AddAttack(Attack atk)
        {
            listAttack.Add(atk);
        }

        public Attack GetAttack(string name)
        {
            foreach(Attack attack in listAttack)
            {
                if(attack.GetAttackName().Equals(name))
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
                if (p.GetAttackName() != "Melee")
                {
                    ret.Add(p.GetAttackName());
                }
            }
            return ret;
        }

        public List<int> GetListCost()
        {
            List<int> ret = new List<int>();
            foreach (Attack p in listAttack)
            {
                if (p.GetAttackName() != "Melee")
                {
                    ret.Add(p.GetCost());
                }
            }
            return ret;
        }
       
        public string GetName()
        {
            return name;
        }

        public void SetName(string n)
        {
            name = n;
        }


        public override string ToString()
        {
            return $"Name: {name}\nHealth: {stats.GetActualHealth()} / {stats.GetMaxHealth()}\nMana: {stats.GetActualMana()} / {stats.GetMaxMana()}\nAttack: {stats.GetAttack()}\nDefense: {stats.GetDefense()}\nAgility: {stats.GetAgility()}\nIntelligence: {stats.GetIntel()}\nLuck: {stats.GetLuck()}\n";
        }

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
