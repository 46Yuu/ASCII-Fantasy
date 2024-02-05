using System;
using System.Collections.Generic;
using System.Numerics;

namespace ASCIIFantasy
{
    public class Character 
    {
        protected string name;
        protected StatsCharacter stats { get; set; }
        protected Dictionary<string, Attack> listAttack = new Dictionary<string, Attack>();
        protected Gear CharacterGear { get;}

        public Character()
        {
            name = "&&&";
            stats = new StatsCharacter();
            CharacterGear = new Gear();
        }

        public Character(string n, int hp, int man, int atk, int def, int intel, int agi, int luc)
        {
            name = n;
            stats = new StatsCharacter(hp,man,atk,def,intel,agi,luc);
            AddAttack("Melee");
            CharacterGear = new Gear();
        }

        public void AddAttack(string name)
        {
            Attack attack = new Attack(name);
            listAttack.Add(name, attack);
        }

        public Attack GetAttack(string name)
        {
            if (listAttack.ContainsKey(name))
            {
                return listAttack[name];
            }
            else
            {
                throw new Exception("Attack not found");
            }
        }

        public StatsCharacter GetStats()
        {
            return stats;
        }

        public List<string> GetListSpells()
        {
            List<string> ret = new List<string>();
            foreach (var p in listAttack)
            {
                if (p.Key != "Melee")
                {
                    ret.Add(p.Key);
                }
            }
            return ret;
        }

        public List<int> GetListCost()
        {
            List<int> ret = new List<int>();
            foreach (var p in listAttack)
            {
                if (p.Key != "Melee")
                {
                    ret.Add(p.Value.GetCost());
                }
            }
            return ret;
        }
       
        public string GetName()
        {
            return name;
        }

        public Gear GetGear()
        {
            return CharacterGear;
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
