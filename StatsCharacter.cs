﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASCIIFantasy
{
    public class StatsCharacter
    {
        private int health;
        private int mana;
        private int attack;
        private int defense;
        private int intelligence;
        private int agility;
        private int speed;
        private int luck;
        private int actual_hp;
        private int actual_mana;
        /*private int level = 1;
        private int xp = 0;
        private int xp_needed = 100;*/

        public StatsCharacter()
        {
            health = 0;
            mana = 0;
            attack = 0;
            defense = 0;
            intelligence = 0;
            agility = 0;
            luck = 0;
            actual_hp = health;
            actual_mana = mana;
        }

        public StatsCharacter(int health, int mana, int attack, int defense, int intelligence, int agility, int luck)
        {
            this.health = health;
            this.mana = mana;
            this.attack = attack;
            this.defense = defense;
            this.intelligence = intelligence;
            this.agility = agility;
            this.luck = luck;
            this.actual_hp = health;
            this.actual_mana = mana;
        }

        public void SetStats(int health, int mana, int attack, int defense, int intelligence, int agility, int luck)
        {
            this.health = health;
            this.mana = mana;
            this.attack = attack;
            this.defense = defense;
            this.intelligence = intelligence;
            this.agility = agility;
            this.luck = luck;
            this.actual_hp = health;
            this.actual_mana = mana;
        }

        public void IncrementHealth(int i)
        {
            actual_hp += i;
            if (actual_hp > health) actual_hp = health;
            else if (actual_hp < 0) actual_hp = 0;
        }

        public void IncrementMana(int i)
        {
            actual_mana += i;
        }

        public void IncrementAttack(int i)
        {
            attack += i;
        }

        public void IncrementDefense(int i)
        {
            defense += i;
        }


        public void IncrementIntel(int i)
        {
            intelligence += i;
        }

        public void IncrementAgility(int i)
        {
            agility += i;
        }

        public void IncrementLuck(int i)
        {
            luck += i;
        }

        public int GetMaxHealth()
        {
            return health;
        }

        public int GetMaxMana()
        {
            return mana;
        }

        public int GetAttack()
        {
            return attack;
        }

        public int GetDefense()
        {
            return defense;
        }

        public int GetActualMana()
        {
            return actual_mana;
        }

        public int GetIntel()
        {
            return intelligence;
        }

        public int GetAgility()
        {
            return agility;
        }

        public int GetLuck()
        {
            return luck;
        }

        public int GetActualHealth()
        {
            return actual_hp;
        }

        public void ShowHealth()
        {
            Console.Write(" Health: ");
            int healthPercentage = (int)((double)actual_hp / health * 100);
            int totalSegments = 20;
            int filledSegments = healthPercentage / 5;
            if (healthPercentage > 50)
                Console.ForegroundColor = ConsoleColor.Green;
            else if (healthPercentage > 25)
                Console.ForegroundColor = ConsoleColor.Yellow;
            else
                Console.ForegroundColor = ConsoleColor.Red;
            for (int i = 0; i < filledSegments; i++)
                Console.Write("█");
            Console.ResetColor();
            for (int i = filledSegments; i < totalSegments; i++)
                Console.Write("_");
            Console.Write(" " + actual_hp + "/" + health);
        }

        public void ShowMana()
        {
            Console.Write(" Mana: ");
            int manaPercentage = (int)((double)actual_mana / mana * 100);
            int totalSegments = 20;
            int filledSegments = manaPercentage / 5;
            Console.ForegroundColor = ConsoleColor.Blue;
            for (int i = 0; i < filledSegments; i++)
                Console.Write("█");
            Console.ResetColor();
            for (int i = filledSegments; i < totalSegments; i++)
                Console.Write("_");
            Console.WriteLine(" " + actual_mana + "/" + mana);
        }
    }
}
