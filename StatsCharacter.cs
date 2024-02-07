using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASCIIFantasy
{
    public class StatsCharacter
    {
        public List<int> statsList = new List<int>();
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
        private int gearBonusHealth;
        private int gearBonusMana;
        private int gearBonusAttack;
        private int gearBonusDefense;
        private int gearBonusIntelligence;
        private int gearBonusAgility;
        private int gearBonusLuck;




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
            statsList.Add(health);
            statsList.Add(mana);
            statsList.Add(attack);
            statsList.Add(defense);
            statsList.Add(intelligence);
            statsList.Add(agility);
            statsList.Add(luck);
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
            statsList.Add(health);
            statsList.Add(mana);
            statsList.Add(attack);
            statsList.Add(defense);
            statsList.Add(intelligence);
            statsList.Add(agility);
            statsList.Add(luck);
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
            if (actual_mana > mana) actual_mana = mana;
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

        public int GetBonusHealth()
        {
            return gearBonusHealth;
        }

        public int GetBonusMana()
        {
            return gearBonusMana;
        }
        public int GetBonusAttack()
        {
            return gearBonusAttack;
        }
        public int GetBonusDefense()
        {
            return gearBonusDefense;
        }

        public int GetBonusIntelligence()
        {
            return gearBonusIntelligence;
        }
        public int GetBonusAgility()
        {
            return gearBonusAgility;
        }

        public int GetBonusLuck()
        {
            return gearBonusLuck;
        }

        public void SetBonusHealth(int i)
        {
            gearBonusHealth = i;
        }

        public void SetBonusMana(int i)
        {
            gearBonusMana = i;
        }
        public void SetBonusAttack(int i)
        {
            gearBonusAttack = i;
        }
        public void SetBonusDefense(int i)
        {
            gearBonusDefense = i;
        }
        public void SetBonusIntelligence(int i)
        {
            gearBonusIntelligence = i;
        }
        public void SetBonusAgility(int i)
        {
            gearBonusAgility = i;
        }
        public void SetBonusLuck(int i)
        {
            gearBonusLuck = i;
        }


        public void ShowHealth()
        {
            Console.WriteLine($"Life: {actual_hp}/{health}");
        }

        public void ShowMana()
        {
            Console.WriteLine($"Mana: {actual_mana}/{mana}");
        }
    }
}
